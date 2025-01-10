using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ENV.Data.DataProvider;
using ENV.Utilities;
using Firefly.Box;
using Firefly.Box.Data.DataProvider;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace ENV.Data.DataProvider
{
    public static class OracleHelper
    {
        public static bool IWISO8859P8Server
        {
            get { return NLSFixer is IWISO8859P9ServerFixer; }
            set
            {
                if (value)
                    NLSFixer = new IWISO8859P9ServerFixer();
                else
                    NLSFixer = new DatabaseStringFixer();
            }
        }
        public static bool WEISO8859P15Server
        {
            get { return NLSFixer is WE8ISO8859P15ServerFixer; }
            set
            {
                if (value)
                    NLSFixer = new WE8ISO8859P15ServerFixer();
                else
                    NLSFixer = new DatabaseStringFixer();
            }
        }
        static OracleHelper()
        {
            Environment.SetEnvironmentVariable("ORA_NCHAR_LITERAL_REPLACE", "TRUE");
        }
        public static bool SupportEmptyDateTime { get; set; }
        public static void UseMicrosoftOracleClient()
        {

        }
        internal static DatabaseStringFixer NLSFixer = new DatabaseStringFixer();

        class IWISO8859P9ServerFixer : DatabaseStringFixer
        {
            public override string fromDb(string s)
            {
                return s.Replace("¤", "₪");
            }
            public override string toDb(string s)
            {
                return s.Replace("₪", "¤");
            }
        }
        class WE8ISO8859P15ServerFixer : DatabaseStringFixer
        {

            public override string fromDb(string s)
            {
                return s.Replace("\u0080", "€")
                    .Replace((char)381, (char)180);

            }

            public override string toDb(string s)
            {
                return s.Replace("€", "\u0080").Replace(
                    (char)180, (char)381);
            }

        }

        /// <summary>
        /// We set this to true - because of cases where the db column may be char but the storage doesn't reflect that W9437
        /// </summary>
        public static bool AlwaysUseChar = true;



        public interface OracleValueSaver : IValueSaver
        {
            void SaveNClobString(string value, int length);
            void SaveClobAnsiString(string value, int length);
            void SaveOracleDate(OracleDate oracleDate);
            void SaveOracleBlob(byte[] value);
            void SaveOracleClob(byte[] value);
        }

        internal class OracleClientParameter : DbDataParameterFilterItemSaver, OracleValueSaver
        {
            bool _useNamedParaneters;
            IDbCommand _command;
            public OracleClientParameter(IDbCommand command, bool useNamedParameters, IDateTimeCollector dtc)
                : base(command, ":p", false, dtc)
            {
                _command = command;
                _useNamedParaneters = useNamedParameters;
            }
            protected override string CreateParameterName(int parameterCount)
            {
                if (!_useNamedParaneters)
                    return ":p";
                return base.CreateParameterName(parameterCount);
            }
            public override void SaveAnsiString(string value, int length, bool fixedWidth)
            {

                value = NLSFixer.toDb(value);
                var p = ((OracleParameter)PrepareStringParameter(value, length,fixedWidth));
                //p.Direction = ParameterDirection.InputOutput;//ora-01460 F6262
                if (length > 4000 || length == 0 && !string.IsNullOrEmpty(value) && value.Length > 4000)// specifically for managed client bug with clob - W3488
                {
                    p.OracleDbType = OracleDbType.Long;//w4221 - clob works great with long and not vice verca
                    p.Direction = ParameterDirection.Input;
                }
                else if (fixedWidth || AlwaysUseChar)
                    p.OracleDbType = OracleDbType.Char;//specifically Char, as we found out that if we use VARCHAR on a field that has char in it, it doesn't work right
                if (p.Value.Equals("\0"))
                    p.Value = DBNull.Value;

            }

            public void SaveClobAnsiString(string value, int length)
            {

                value = NLSFixer.toDb(value);
                var p = ((OracleParameter)PrepareStringParameter(value, length,false));
                p.OracleDbType = OracleDbType.Clob;

                if (p.Value.Equals("\0"))
                    p.Value = DBNull.Value;
            }
            public void SaveNClobString(string value, int length)
            {

                value = NLSFixer.toDb(value);
                var p = ((OracleParameter)PrepareStringParameter(value, length, false));
                //p.OracleDbType = OracleDbType.NClob; issue F14601 - oracle error: ORA-64219 - seems like a bug in managed data access regarding oracle 18/19

                if (p.Value.Equals("\0"))
                    p.Value = DBNull.Value;
            }

            public void SaveOracleDate(OracleDate oracleDate)
            {
                var p = (OracleParameter)CreateParameter();
                p.Value = oracleDate;
                p.OracleDbType = OracleDbType.Date;

            }

            bool StringIsBig(object value)
            {
                var x = value as string;
                if (x != null)
                    return x.Length > 4000;
                return false;
            }

            public override void SaveString(string value, int length, bool fixedWidth)
            {

                value = NLSFixer.toDb(value);
                var p = ((OracleParameter)PrepareStringParameter(value, length,fixedWidth));
                //p.Direction = ParameterDirection.InputOutput;//ora-01460 F6262
                if (length > 4000 && StringIsBig(p.Value) || length == 0 && !string.IsNullOrEmpty(value) && value.Length > 4000)// specifically for managed client bug with clob - W3488
                {
                    p.OracleDbType = OracleDbType.Long;//w4221 - clob works great with long and not vice verca
                    p.Direction = ParameterDirection.Input;
                }
                else if (fixedWidth || AlwaysUseChar)
                    p.OracleDbType = OracleDbType.NChar;//specifically Char, as we found out that if we use VARCHAR on a field that has char in it, it doesn't work right
                else
                    p.OracleDbType = OracleDbType.NVarchar2;
                if (p.Value.Equals("\0"))
                    p.Value = DBNull.Value;
            }
            protected override void SaveDecimalNumber(IDbDataParameter x, decimal value, byte precision, byte scale)
            {
                x.DbType = DbType.Decimal;
                x.Value = value;

            }

            protected override DbType GetDateTimeDbType(DateTime value)
            {
                return DbType.Date;
            }

            public override void SaveEmptyDateTime()
            {
                base.TextForCommand = "EmptyDate";
            }

            public void SaveOracleBlob(byte[] value)
            {
                var p = (OracleParameter)base.CreateParameter();
                var blob = new OracleBlob((OracleConnection)_command.Connection);
                blob.Write(value, 0, value.Length);
                p.OracleDbType = OracleDbType.Blob;
                p.Value = blob;

            }
            public void SaveOracleClob(byte[] value)
            {
                var p = (OracleParameter)base.CreateParameter();
                p.OracleDbType = OracleDbType.Clob;
                p.Value = value;

            }
        }
        static bool _loadedIniSettings = false;
        public static void UseOracleODPClient(string nlsDateFormat, string nlsSort, string nlsNumericCharacters, string language = null, string territory = null)
        {
            Init();
            BtrieveEntity.CreateRowIdColumn = () => new ENV.Data.OracleEntity.OracleRowID();
            ConnectionManager.SetOracleConnectionFactory(
           connectionString =>
           {
               var y = ENV.UserMethods.Instance.IniGet("[ORACLE_TEST]StatementCache");
               if (y == "")
                   y = "50";
               if (y != "0" && y != "N" && y != "n")
                   connectionString += "Statement Cache Size=" + Number.Parse(y).ToString();
               return new OracleConnectionWrapper(new OracleConnection(connectionString),
                    nlsDateFormat, nlsSort, nlsNumericCharacters, ConnectionManager.UseOracleNamedParameter, language, territory);
           },
           dataProvider =>
           {
               if (!_loadedIniSettings)
               {
                   _loadedIniSettings = true;
                   Func<string, bool> checkValue = x =>
                   {
                       var y = ENV.UserMethods.Instance.IniGet("[ORACLE_TEST]" + x);
                       if (y == null)
                           return false;
                       y = y.ToUpper().Trim();
                       return y == "Y";
                   };
                   if (checkValue("AlwaysUseChars"))
                   {
                       AlwaysUseChar = true;
                   }
                   if (checkValue("DisableUIControllerHint"))
                       OracleEntity.DisableUIControllerHint = true;
                   if (checkValue("DisableRelationHint"))
                       OracleEntity.DisableRelationHint = true;


               }
               if (ENV.Data.DataProvider.ConnectionManager.UseDBParameters)
                   dataProvider.SetFactories((x, dtc) => new OracleClientParameter(x, ConnectionManager.UseOracleNamedParameter, dtc), (r, i, dtc) => new OracleDataReaderValueLoader(r, i, dtc));
               dataProvider.SetHintProvider(ENV.Data.OracleEntity.HintProvider);
               dataProvider.UseNamedParameters = ConnectionManager.UseOracleNamedParameter;
           });
        }

        internal static void Init()
        {
            DynamicSQLSupportingDataProvider._processTextParameter = (tc, p) =>
            {
                if (tc.FormatInfo.MaxDataLength > 4000)
                {
                    var op = p as OracleParameter;
                    if (op != null)
                    {
                        op.OracleDbType = OracleDbType.Long;
                        op.Size = tc.FormatInfo.MaxDataLength;
                    }
                }
            };
            DynamicSQLSupportingDataProvider._processByteArrayParameter = (tc, p) =>
            {
                {
                    var op = p as OracleParameter;
                    if (op != null && (tc.Storage is ENV.Data.Storage.AnsiStringOracleCLOBByteArrayStorage))
                    {
                        op.OracleDbType = OracleDbType.Clob;
                        op.Size = 0;
                    }
                }
            };
            DynamicSQLSupportingDataProvider._translateResultParamValue = x =>
            {
                var clob = x as OracleClob;
                if (clob != null)
                {
                    return clob.Value;
                }
                return x;
            };
        }

        public static void UseOracleODPClient()
        {
            UseOracleODPClient(null, null, null);

        }
    }

    class OracleDataReaderValueLoader : DataReaderValueLoader
    {

        public OracleDataReaderValueLoader(IDataReader reader, int position, IDateTimeCollector dtc)
            : base(reader, position, dtc)
        {

        }

        public Oracle.ManagedDataAccess.Types.OracleDate GetOracleDate()
        {
            return ((OracleConnectionWrapper.OracleCommandWrapper.OracleDataReaderWrapper)_reader).GetOracleDate(_position);
        }
    }

}

namespace ENV.Data.Storage
{
    public class AnsiStringOracleCLOBByteArrayStorage : IColumnStorageSrategy<byte[]>, IStorageScriptCreator
    {
        public byte[] LoadFrom(IValueLoader loader)
        {
            if (loader.IsNull())
                return null;
            var s = loader.GetString();
            return ByteArrayColumn.ToAnsiByteArray(s);
        }

        public void SaveTo(byte[] value, IValueSaver saver)
        {
            if (value == null)
            {
                saver.SaveNull();
                return;
            }
            var s = ByteArrayColumn.AnsiByteArrayToString(value);
            var o = saver as OracleHelper.OracleValueSaver;
            if (o == null)
                saver.SaveAnsiString(s, s.Length, false);
            else
                o.SaveNClobString(s, s.Length);
        }
        public void AddTo(SqlScriptTableCreator sql, string name, string caption, bool allowNull, ScriptHelper helper)
        {
            sql.AddText(name, caption, "9999", allowNull, false, false, helper);
        }
    }
    public class OracleNCLOBByteArrayStorage : IColumnStorageSrategy<byte[]>, IStorageScriptCreator
    {
        public byte[] LoadFrom(IValueLoader loader)
        {
            if (loader.IsNull())
                return null;
            var s = loader.GetString();
            return ByteArrayColumn.ToUnicodeByteArray(s);
        }

        public void SaveTo(byte[] value, IValueSaver saver)
        {
            if (value == null)
            {
                saver.SaveNull();
                return;
            }
            var s = ByteArrayColumn.AnsiByteArrayToString(value);
            var o = saver as OracleHelper.OracleValueSaver;
            if (o == null)
                saver.SaveString(s, s.Length, false);
            else
                o.SaveClobAnsiString(s, s.Length);
        }
        public void AddTo(SqlScriptTableCreator sql, string name, string caption, bool allowNull, ScriptHelper helper)
        {
            sql.AddText(name, caption, "9999", allowNull, false, false, helper);
        }
    }
    public class OracleBlobByteArrayStorage : IColumnStorageSrategy<byte[]>, IStorageScriptCreator
    {
        public byte[] LoadFrom(IValueLoader loader)
        {
            if (loader.IsNull())
                return null;
            return loader.GetByteArray();
        }

        public void SaveTo(byte[] value, IValueSaver saver)
        {
            if (value == null)
            {
                saver.SaveNull();
                return;
            }
            var o = saver as OracleHelper.OracleValueSaver;
            if (o == null)
                saver.SaveByteArray(value);
            else
                o.SaveOracleBlob(value);
        }


        public void AddTo(SqlScriptTableCreator sql, string name, string caption, bool allowNull, ScriptHelper helper)
        {
            sql.AddBinary(name, caption, int.MaxValue);
        }
    }
    public class OracleClobByteArrayStorage : IColumnStorageSrategy<byte[]>, IStorageScriptCreator
    {
        public byte[] LoadFrom(IValueLoader loader)
        {
            if (loader.IsNull())
                return null;
            return ByteArrayColumn.UnicodeWithoutGaps.GetBytes(loader.GetString());
        }

        public void SaveTo(byte[] value, IValueSaver saver)
        {
            if (value == null)
            {
                saver.SaveNull();
                return;
            }
            var o = saver as OracleHelper.OracleValueSaver;
            if (o == null)
                saver.SaveByteArray(value);
            else
            {
                var s = ByteArrayColumn.UnicodeWithoutGaps.GetString(value);

                o.SaveNClobString(s,s.Length);
            }
        }


        public void AddTo(SqlScriptTableCreator sql, string name, string caption, bool allowNull, ScriptHelper helper)
        {
            sql.AddText(name, caption, "9999", allowNull, false, false, helper);
        }
    }
    public class OracleDateTimeTextStorage : Firefly.Box.Data.DataProvider.IColumnStorageSrategy<Text>, ENV.Utilities.IStorageScriptCreator
    {
        static Text ZeroReplacementText = "8080-80-80 00:00:00";
        static DateTime ZeroReplacement = DateTimeDateStorage.ZeroReplacement.ToDateTime();

        public Text LoadFrom(IValueLoader loader)
        {
            if (loader.IsNull())
                return null;
            var o = loader as OracleDataReaderValueLoader;
            if (o != null)
            {
                try
                {
                    var x = o.GetOracleDate();
                    return string.Concat(x.Year.ToString("0000"), "-", x.Month.ToString("00"),
                        "-" + x.Day.ToString("00"), " ",
                        x.Hour.ToString("00"), ":", x.Minute.ToString("00"), ":", x.Second.ToString("00"));

                }
                catch
                {
                    return ZeroReplacementText;
                }
            }




            try
            {
                var x = loader.GetDateTime();
                if (x == ZeroReplacement)
                    return ZeroReplacementText;
                else
                    return x.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                return ZeroReplacementText;
            }

        }

        public void SaveTo(Text value, IValueSaver saver)
        {
            if (object.ReferenceEquals(value, null))
                saver.SaveNull();
            else
            {
                var o = saver as OracleHelper.OracleValueSaver;
                if (o != null)
                {
                    try
                    {
                        var x = value.ToString().Trim().PadLeft(19, '0');
                        o.SaveOracleDate(new OracleDate(
                            int.Parse(x.Substring(0, 4)),
                            int.Parse(x.Substring(5, 2)),
                            int.Parse(x.Substring(8, 2)),
                            int.Parse(x.Substring(11, 2)),
                            int.Parse(x.Substring(14, 2)),
                            int.Parse(x.Substring(17, 2))));
                    }
                    catch
                    {
                        saver.SaveDateTime(DateTime.Now);
                    }
                    return;
                }
                DateTime dt;
                if (!DateTime.TryParse(value, CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.None, out dt))
                {
                    if (value.Length >= 18)
                    {
                        var v = value.ToString().ToCharArray();
                        v[13] = ':';
                        v[16] = ':';
                        if (!DateTime.TryParse(new string(v), out dt))
                            dt = ZeroReplacement;
                    }
                    else if (value.Length > 10)
                    {
                        if (!DateTime.TryParse(value.Remove(10), out dt))
                            dt = ZeroReplacement;
                    }
                    else
                        dt = ZeroReplacement;
                }
                saver.SaveDateTime(dt);
            }

        }
        public void AddTo(SqlScriptTableCreator sql, string name, string caption, bool allowNull, ScriptHelper helper)
        {
            sql.AddDateTime(name, caption, allowNull, helper);
        }
    }
}

