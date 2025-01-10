using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Firefly.Box.Data.Advanced;
using Firefly.Box.Data.DataProvider;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Firefly.Box;
using ENV.Security;
using ENV.Utilities;
using ENV.Data;
using ENV;
using ENV.Data.DataProvider;
using Firefly.Box.Data.UnderConstruction;
namespace ENV.Data.DataProvider
{
    class OracleConnectionWrapper : IDbConnection
    {
        IDbConnection _connection;
        OracleConnection _con;
        string _nlsDateFormat;
        string _nlsSort, _language, _territory;
        string _nlsNumericCharacters;
        const decimal _intMin = int.MinValue, _intMax = int.MaxValue;
        static object TranslateOracleDecimal(OracleDecimal x)
        {
            if (x.IsNull)
                return DBNull.Value;
            if (x.IsInt && x.Value < _intMax && x > _intMin)
                return x.ToInt32();
            else
                return OracleDecimal.SetPrecision(x, 28).Value;
        }
        internal static void Reset()
        {
            _preProcessSQL = s => s;
        }

        static OracleConnectionWrapper()
        {
            Reset();
        }
#if DEBUG
        public static long ReadCounter = 0;
#endif

        internal static Func<string, string> _preProcessSQL;
        bool _useNamedParameters;
        public OracleConnectionWrapper(OracleConnection connection, string nlsDateFormat, string nlsSort, string nlsNumericCharacters, bool useNamedParameter, string language = null, string territory = null)
        {
            _useNamedParameters = useNamedParameter;
            _connection = connection;
            _nlsDateFormat = nlsDateFormat;
            _language = ENV.PathDecoder.DecodePath(language);
            _territory = ENV.PathDecoder.DecodePath(territory);
            if (!string.IsNullOrEmpty(_nlsDateFormat))
            {
                _nlsDateFormat = _nlsDateFormat.Replace('D', 'd');
                _nlsDateFormat = _nlsDateFormat.Replace('Y', 'y');
            }
            _nlsSort = nlsSort;
            _nlsNumericCharacters = nlsNumericCharacters;
            _con = connection;
        }

        internal static void VerifyExistanceOfEmptyDate(IDbCommand com)
        {
            using (com)
            {
                com.CommandText = "select emptydate from dual";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    if (ex.Message.StartsWith("ORA-00904"))
                    {
                        com.CommandText =
@"create or replace function EmptyDate return date deterministic is
  v_date date;
begin
  dbms_stats.CONVERT_RAW_VALUE('64640000010101', v_date);
  return v_date;
end;
";
                        try
                        {
                            com.ExecuteNonQuery();
                        }
                        catch { }

                    }
                }
            }

        }


        public void Dispose()
        {
            _connection.Dispose();
        }

        public IDbTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _connection.BeginTransaction(il);
        }

        public void Close()
        {
            _connection.Close();
        }

        public void ChangeDatabase(string databaseName)
        {
            _connection.ChangeDatabase(databaseName);
        }

        public IDbCommand CreateCommand()
        {
            var x = _con.CreateCommand();
            if (_useNamedParameters)
                x.BindByName = true;
            x.InitialLONGFetchSize = -1;
            return new OracleCommandWrapper(x, this);
        }
        internal class OracleCommandWrapper : IDbCommand, IDbCommandWrapper
        {
            IDbCommand _command;
            OracleCommand _oCommand;
            OracleConnectionWrapper _parent;

            public OracleCommandWrapper(OracleCommand oCommand, OracleConnectionWrapper parent)
            {
                _oCommand = oCommand;
                _parent = parent;
                _command = oCommand;
            }

            public void Dispose()
            {
                _command.Dispose();
            }

            public void Prepare()
            {
                _command.Prepare();
            }

            public void Cancel()
            {
                _command.Cancel();
            }

            public IDbDataParameter CreateParameter()
            {
                return _command.CreateParameter();
            }

            public int ExecuteNonQuery()
            {
                bool checkParams = false;

                if (_command.CommandText.StartsWith("BEGIN", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (_command.CommandText.ToUpper().Contains("CLOSE_DATABASE_LINK"))
                        _parent._con.PurgeStatementCache();
                    foreach (OracleParameter op in _oCommand.Parameters)
                    {
                        if (op.DbType == DbType.Decimal)
                        {
                            op.OracleDbType = OracleDbType.Decimal;
                            checkParams = true;
                        }
                    }
                }
                var result = _command.ExecuteNonQuery();
                if (checkParams)
                    foreach (OracleParameter op in _oCommand.Parameters)
                    {
                        if (op.Value is OracleDecimal)
                        {
                            var x = (OracleDecimal)op.Value;
                            op.Value = TranslateOracleDecimal(x);
                        }
                    }
                for (int i = 0; i < _oCommand.Parameters.Count; i++)
                {
                    var disp = _oCommand.Parameters[i].Value as OracleBlob;
                    if (disp != null)
                        disp.Dispose();
                }
                
                return result;
            }

            public IDataReader ExecuteReader()
            {
                return new OracleDataReaderWrapper(_oCommand.ExecuteReader(), this);
            }

            public IDataReader ExecuteReader(CommandBehavior behavior)
            {
                return new OracleDataReaderWrapper(_oCommand.ExecuteReader(behavior), this);
            }
            public class OracleDataReaderWrapper : IDataReader
            {
                IDataReader _reader;
                OracleDataReader _oReader;
                OracleCommandWrapper _parent;

                public OracleDataReaderWrapper(OracleDataReader oReader, OracleCommandWrapper parent)
                {
                    _oReader = oReader;
                    _parent = parent;
                    _reader = oReader;
                }

                public void Dispose()
                {
                    _reader.Dispose();
                }

                public string GetName(int i)
                {
                    return _reader.GetName(i);
                }

                public string GetDataTypeName(int i)
                {
                    return _reader.GetDataTypeName(i);
                }

                public Type GetFieldType(int i)
                {
                    return _reader.GetFieldType(i);
                }

                public object GetValue(int i)
                {
                    return _reader.GetValue(i);
                }

                public int GetValues(object[] values)
                {
                    return _reader.GetValues(values);
                }

                public int GetOrdinal(string name)
                {
                    return _reader.GetOrdinal(name);
                }

                public bool GetBoolean(int i)
                {
                    return _reader.GetBoolean(i);
                }

                public byte GetByte(int i)
                {
                    return _reader.GetByte(i);
                }

                public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
                {
                    return _reader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
                }

                public char GetChar(int i)
                {
                    return _reader.GetChar(i);
                }

                public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
                {
                    return _reader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
                }

                public Guid GetGuid(int i)
                {
                    return _reader.GetGuid(i);
                }

                public short GetInt16(int i)
                {
                    return _reader.GetInt16(i);
                }

                public int GetInt32(int i)
                {
                    return _reader.GetInt32(i);
                }

                public long GetInt64(int i)
                {
                    return _reader.GetInt64(i);
                }

                public float GetFloat(int i)
                {
                    return _reader.GetFloat(i);
                }

                public double GetDouble(int i)
                {
                    return _reader.GetDouble(i);
                }

                public string GetString(int i)
                {

                    var value = _reader.GetString(i);
                    value = OracleHelper.NLSFixer.fromDb(value);

                    return value;
                }

                public decimal GetDecimal(int i)
                {
                    return _reader.GetDecimal(i);
                }

                public DateTime GetDateTime(int i)
                {
                    return _reader.GetDateTime(i);
                }

                public IDataReader GetData(int i)
                {
                    return _reader.GetData(i);
                }

                public bool IsDBNull(int i)
                {
                    return _reader.IsDBNull(i);
                }

                public int FieldCount
                {
                    get { return _reader.FieldCount; }
                }

                bool[] _isDecimal, _isDate;

                public object this[int i]
                {
                    get
                    {
                        if (_isDecimal == null)
                        {
                            var l = _reader.FieldCount;
                            _isDecimal = new bool[l];
                            _isDate = new bool[l];
                            bool hasNls = !string.IsNullOrEmpty(_parent._parent._nlsDateFormat);
                            for (int j = 0; j < l; j++)
                            {
                                var dataTypeName = _oReader.GetDataTypeName(j);
                                _isDecimal[j] = dataTypeName == "Decimal";
                                _isDate[j] = dataTypeName == "Date" && hasNls;
                            }
                        }
                        if (_isDecimal[i])
                        {
                            if (_oReader.IsDBNull(i))
                                return DBNull.Value;
                            var x = _oReader.GetOracleDecimal(i);
                            return TranslateOracleDecimal(x);
                        }
                        if (_isDate[i])
                        {
                            if (_oReader.IsDBNull(i))
                                return DBNull.Value;
                            return string.Format("{0} {1}",
                                _reader.GetDateTime(i).ToString(_parent._parent._nlsDateFormat),
                                _reader.GetDateTime(i).ToLongTimeString());
                        }
                        var r = _reader[i];
                        var value = r as string;
                        if (value != null)
                        {

                            return OracleHelper.NLSFixer.fromDb(value);
                        }
                        return r;
                    }
                }



                public object this[string name]
                {
                    get { return _reader[name]; }
                }

                public void Close()
                {
                    _reader.Close();
                }

                public DataTable GetSchemaTable()
                {
                    return _reader.GetSchemaTable();
                }

                public bool NextResult()
                {
                    return _reader.NextResult();
                }

                public bool Read()
                {
#if DEBUG
                    ReadCounter++;
#endif
                    return _reader.Read();
                }

                public int Depth
                {
                    get { return _reader.Depth; }
                }

                public bool IsClosed
                {
                    get { return _reader.IsClosed; }
                }

                public int RecordsAffected
                {
                    get { return _reader.RecordsAffected; }
                }

                public OracleDate GetOracleDate(int position)
                {
                    return ((OracleDataReader)_reader).GetOracleDate(position);
                }
            }

            public object ExecuteScalar()
            {
                return _command.ExecuteScalar();
            }

            public IDbConnection Connection
            {
                get { return _command.Connection; }
                set { _command.Connection = value; }
            }

            public IDbTransaction Transaction
            {
                get { return _command.Transaction; }
                set { _command.Transaction = value; }
            }

            public string CommandText
            {
                get { return _command.CommandText; }
                set
                {

                    value = OracleHelper.NLSFixer.toDb(value);
                    _command.CommandText = _preProcessSQL(value);
                }
            }

            public int CommandTimeout
            {
                get { return _command.CommandTimeout; }
                set { _command.CommandTimeout = value; }
            }

            public CommandType CommandType
            {
                get { return _command.CommandType; }
                set { _command.CommandType = value; }
            }

            public IDataParameterCollection Parameters
            {
                get { return _command.Parameters; }
            }

            public UpdateRowSource UpdatedRowSource
            {
                get { return _command.UpdatedRowSource; }
                set { _command.UpdatedRowSource = value; }
            }

            public IDbCommand GetOriginalCommand()
            {
                return _command;
            }
        }


        public void Open()
        {
            _connection.Open();
            var x = _con.GetSessionInfo();
            /*if (x.Language == "HEBREW")
            {
                x.Language = "AMERICAN";
                x.Territory = "AMERICA";
            }*/
            if (!string.IsNullOrEmpty(_nlsSort))
                x.Sort = _nlsSort;
            if (!string.IsNullOrEmpty(_language))
                x.Language = _language;
            if (!string.IsNullOrEmpty(_territory))
                x.Territory = _territory;

            if (!string.IsNullOrEmpty(_nlsNumericCharacters))
                x.NumericCharacters = _nlsNumericCharacters;
            if (!string.IsNullOrEmpty(_nlsDateFormat))
                x.DateFormat = _nlsDateFormat;
            _con.SetSessionInfo(x);
            if (OracleHelper.SupportEmptyDateTime)
                VerifyExistanceOfEmptyDate(CreateCommand());
        }

        public string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }

        public int ConnectionTimeout
        {
            get { return _connection.ConnectionTimeout; }
        }

        public string Database
        {
            get { return _connection.Database; }
        }

        public ConnectionState State
        {
            get { return _connection.State; }
        }


    }

}
namespace ENV.Data
{

    public class OracleEntity : ENV.Data.Entity
    {
        public OracleEntity(string entityName, string caption, IEntityDataProvider dataProvider)
            : base(entityName, caption, dataProvider)
        {
        }

        public OracleEntity(string entityName, IEntityDataProvider dataProvider)
            : base(entityName, dataProvider)
        {
        }
        public static bool DisableUIControllerHint = true;
        public static bool DisableRelationHint = true;
        public string Hint { get; set; }
        public static string HintProvider(bool onlyOneRow, Firefly.Box.Data.Entity entity, Sort sort, bool uniqueFilter, IEnumerable<ColumnBase> columns, bool optimiseForFirstRows, bool isForRelation)
        {
            var os = sort as OracleSort;
            if (os != null)
            {
                if (!string.IsNullOrEmpty(os.Hint))
                    return os.Hint + " ";
            }
            var oe = entity as OracleEntity;
            if (oe != null && !string.IsNullOrEmpty(oe.Hint))
            {
                if (sort == null || sort.Segments.Count == 0 || oe.Indexes.Contains(sort))
                    return oe.Hint + " ";
            }
            if (!isForRelation)
            {
                if (optimiseForFirstRows && !DisableUIControllerHint)
                {
                    return "/*+FIRST_ROWS(1)*/";//We've tried with FIRST_ROWS(30) but got significantly worst results
                }
            }
            else
            {
                if (!DisableRelationHint)
                {
                    if (!uniqueFilter)
                        return "/*+FIRST_ROWS(1)*/";
                }
            }
            return "";
        }
        protected internal void UseRowIdAsPrimaryKey()
        {
            ColumnBase x = new OracleRowID();
            if (MigratedToMSSQL.Value)
                x = new RowIDInSQLServer();

            Columns.Add(x);
            IdentityColumn = x;
        }
        public readonly static ContextStatic<bool> MigratedToMSSQL = new ContextStatic<bool>(() => false);
        public static void SwitchToSQL()
        {
            MigratedToMSSQL.Value = !MigratedToMSSQL.Value;
            Common.ApplicationTitle = UserMethods.Instance.Sys() +
                (!MigratedToMSSQL.Value ? "" : " MSSQL: ");
            Common.RunOnRootMDI(
                mdi =>
                {
                    mdi.Text = Common.ApplicationTitle;
                    Common.SetDefaultStatusText(Common.ApplicationTitle);
                });
        }


        public class OracleRowID : TextColumn, UserMethods.NotIncludedInVarIndexCalculations, ENV.Data.DataProvider.OracleClientEntityDataProvider.IRowIdColumn
        {
            public OracleRowID() : base(new UserMethods().IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseEnabled").ToUpper().Trim() == "Y" ? "__rowid" : "rowid", "20") { }

        }

        //Original setting
        //public class RowIDInSQLServer : NumberColumn, UserMethods.NotIncludedInVarIndexCalculations
        //{
        //    public RowIDInSQLServer() : base("__sequence", "18") { }
        //}
        public class RowIDInSQLServer : NumberColumn, UserMethods.NotIncludedInVarIndexCalculations
        {
            public RowIDInSQLServer() : base("__rowid", "18") { }
        }

    }

    public class OracleSort : Index
    {
        public OracleSort(params ColumnBase[] columns)
            : base(columns)
        {
        }
        public string Hint { get; set; }
        public override Sort Clone()
        {
            var r = new OracleSort();
            base.PopulateClone(r);
            r.Hint = this.Hint;
            return r;
        }
    }


}
