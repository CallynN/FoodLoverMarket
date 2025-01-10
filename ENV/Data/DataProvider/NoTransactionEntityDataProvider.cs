using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENV.Utilities;
using Firefly.Box;
using Firefly.Box.Data.Advanced;
using Firefly.Box.Data.DataProvider;

namespace ENV.Data.DataProvider
{
    public class NoTransactionEntityDataProvider : ISQLEntityDataProvider, ICanGetDecoratedISSQLEntityDataProvider
    {
        public static void Init()
        {
            ConnectionManager._createNoTransactionDatabase = CreateNoTransactionDatabase;
        }

        private static ISQLEntityDataProvider CreateNoTransactionDatabase(ISQLEntityDataProvider source, bool oracle, bool noLocks)
        {
            if (noLocks)
                return new NoTransactionEntityDataProvider(source, new DummyLockProvider(), ConnectionManager.EnableBtrieveTransactions);
            if (oracle)
                return new NoTransactionEntityDataProvider(source, new OracleLockProvider(), ConnectionManager.EnableBtrieveTransactions);
            else
                return new NoTransactionEntityDataProvider(source, new SQLServerLockProvider(), ConnectionManager.EnableBtrieveTransactions);
        }
        public ISupportsGetDefinition GetSupportGetDefinition()
        {
            return _source.GetSupportGetDefinition();
        }
        bool ISQLEntityDataProvider.IsClosed()
        {
            return _source.IsClosed();
        }
      
        public bool AutoCreateTables { get { return _source.AutoCreateTables; } set { _source.AutoCreateTables = value; } }
        ISQLEntityDataProvider _source;
        public interface LockProvider
        {
            void DoLock(string key, bool release, Func<IDbCommand> createCommand, bool keepLockForTransaction);
            SqlScriptTableCreator CreateScriptGeneratorTable(Firefly.Box.Data.Entity entity);
        }
        public ISQLEntityDataProvider GetSource()
        {
            return (ISQLEntityDataProvider)_source;
        }
        public bool RequiresTransactionForLocking
        {
            get
            {
                return false;
            }
        }

        public static bool ThrowExceptionOnRemainingActiveLocksWhenSourceCloses { get; set; }

        LockProvider _lockProvider;
        bool _useTransactions;
        public NoTransactionEntityDataProvider(ISQLEntityDataProvider source, LockProvider lockProvider, bool useTransactions = false)
        {
            _lockProvider = lockProvider;
            _source = source;
            _useTransactions = useTransactions;

        }

        class DummyTransaction : IMyTransaction
        {
            public void Commit()
            {

            }

            public bool IsOpenTransaction()
            {
                return false;
            }

            public void Rollback()
            {

            }

            public void Unlock(string dbLockString, NoTransactionEntityDataProvider parent)
            {
                parent._lockProvider.DoLock(dbLockString, true, parent.CreateCommand, false);
            }

            public void Update(string dbLockString, NoTransactionEntityDataProvider parent)
            {

            }
        }
        IMyTransaction _activeTransaction = new DummyTransaction();
        public ITransaction BeginTransaction()
        {


            if (_useTransactions)
            {
                if (_activeTransaction.IsOpenTransaction())
                    return _activeTransaction;
                return _activeTransaction = new MyTransaction(_source.BeginTransaction(), this);
            }
            return new DummyTransaction();

        }
        interface IMyTransaction : ITransaction
        {
            bool IsOpenTransaction();
            void Unlock(string dbLockString, NoTransactionEntityDataProvider parent);
            void Update(string dbLockString, NoTransactionEntityDataProvider parent);
        }
        class MyTransaction : IMyTransaction
        {
            ITransaction _original;
            NoTransactionEntityDataProvider _parent;
            public MyTransaction(ITransaction original, NoTransactionEntityDataProvider parent)
            {
                _original = original;
                _parent = parent;
            }

            public void Commit()
            {
                _original.Commit();
                ReleaseAllLocks();
                _parent._activeTransaction = new DummyTransaction();
            }

            public bool IsOpenTransaction()
            {
                return true;
            }

            public void Rollback()
            {
                _original.Rollback();
                ReleaseAllLocks();
                _parent._activeTransaction = new DummyTransaction();
            }

            void ReleaseAllLocks()
            {
                foreach (var item in _unlockCommands)
                {
                    item();
                }
            }
            List<Action> _unlockCommands = new List<Action>();
            public void Unlock(string dbLockString, NoTransactionEntityDataProvider parent)
            {
                if (!_lockedUpdateRows.Contains(dbLockString))
                    parent._lockProvider.DoLock(dbLockString, true, parent.CreateCommand, false);
                else
                    _unlockCommands.Add(() => _parent._lockProvider.DoLock(dbLockString, true, parent.CreateCommand,false));

            }
            HashSet<string> _lockedUpdateRows = new HashSet<string>();
            public void Update(string dbLockString, NoTransactionEntityDataProvider parent)
            {
                while (true)
                    try
                    {
                        parent._lockProvider.DoLock(dbLockString, false, parent.CreateCommand, false);
                        _unlockCommands.Add(() => parent._lockProvider.DoLock(dbLockString, true, parent.CreateCommand, false));
                        _lockedUpdateRows.Add(dbLockString);
                        return;
                    }
                    catch
                    {
                        ENV.UserMethods.Instance.Delay(1);
                    }
            }
        }

        public bool Contains(Firefly.Box.Data.Entity entity)
        {
            return ((IEntityDataProvider)_source).Contains(entity);
        }

        public void Dispose()
        {
            _source.Dispose();
        }

        public long CountRows(Firefly.Box.Data.Entity entity)
        {
            return ((IEntityDataProvider)_source).CountRows(entity);
        }



        public string GetEntityName(Firefly.Box.Data.Entity entity)
        {
            return _source.GetEntityName(entity);
        }

        public IDbCommand CreateCommand()
        {
            return _source.CreateCommand();
        }

        public Exception ProcessException(Exception e, Firefly.Box.Data.Entity entity, IDbCommand c)
        {
            return GetSource().ProcessException(e, entity, c);
        }

        public bool IsOracle { get; private set; }
        public SqlScriptTableCreator CreateScriptGeneratorTable(Firefly.Box.Data.Entity entity)
        {
            return _lockProvider.CreateScriptGeneratorTable(entity);
        }

        public UserDbMethods.IUserDbMethodImplementation GetUserMethodsImplementation()
        {
            return _source.GetUserMethodsImplementation();
        }

        public void Drop(Firefly.Box.Data.Entity entity)
        {
            ((IEntityDataProvider)_source).Drop(entity);
        }



        public IRowsSource ProvideRowsSource(Firefly.Box.Data.Entity entity)
        {
            return new myRowsSource(((IEntityDataProvider)_source).ProvideRowsSource(entity), entity, this);
        }
        class myRowsSource : IRowsSource
        {
            IRowsSource _source;
            Firefly.Box.Data.Entity _entity;
            NoTransactionEntityDataProvider _parent;
            List<myRow> _lockedRows = new List<myRow>();
            public myRowsSource(IRowsSource source, Firefly.Box.Data.Entity entity, NoTransactionEntityDataProvider parent)
            {
                _source = source;
                _entity = entity;
                _parent = parent;
            }

            public IRowsProvider CreateReader(IEnumerable<ColumnBase> selectedColumns, IFilter where, Sort sort, IEnumerable<IJoin> joins, bool disableCache)
            {
                return new myRowsProvider(_source.CreateReader(selectedColumns, where, sort, joins, disableCache), this);
            }
            class myRowsProvider : IRowsProvider
            {
                IRowsProvider _provider;
                myRowsSource _parent;
                public myRowsProvider(IRowsProvider provider, myRowsSource parent)
                {
                    _provider = provider;
                    _parent = parent;
                }

                public IRowsReader After(IRow row, bool reverse)
                {
                    return new myRowsReader(_provider.After(((myRow)row)._row, reverse), _parent);
                }

                public IRowsReader Find(IFilter filter, bool reverse)
                {
                    return new myRowsReader(_provider.Find(filter, reverse), _parent);
                }

                public IRowsReader From(IRow row, bool reverse)
                {
                    return new myRowsReader(_provider.From(((myRow)row)._row, reverse), _parent);
                }

                public IRowsReader From(IFilter filter, bool reverse)
                {
                    return new myRowsReader(_provider.From(filter, reverse), _parent);
                }

                public IRowsReader FromEnd()
                {
                    return new myRowsReader(_provider.FromEnd(), _parent);
                }

                public IRowsReader FromStart()
                {
                    return new myRowsReader(_provider.FromStart(), _parent);
                }
            }

            public void Dispose()
            {
                try
                {
                    if (_lockedRows.Count > 0)
                    {
                        string error = "There are active locks and the provider is disposed:\r\n";
                        foreach (var lockedRow in _lockedRows)
                        {
                            error += lockedRow.GetLockedIdentifier() + "\r\n";
                        }

                        Profiler.StartContext(error).Dispose();
                        if (ThrowExceptionOnRemainingActiveLocksWhenSourceCloses)
                        {
                            throw new InvalidOperationException(error);
                        }
                        else
                        {
                            foreach (var item in _lockedRows.ToArray())
                            {
                                item.Unlock();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Common.ShowExceptionDialog(e);
                    throw e;
                }
                finally
                {
                    _source.Dispose();
                }

            }

            public IRowsReader ExecuteCommand(IEnumerable<ColumnBase> selectedColumns, IFilter filter, Sort sort, bool firstRowOnly, bool shouldBeOnlyOneRowThatMatchesTheFilter, bool lockAllRows)
            {
                return new myRowsReader(_source.ExecuteCommand(selectedColumns, filter, sort, firstRowOnly, shouldBeOnlyOneRowThatMatchesTheFilter, false), this);
            }

            public IRowsReader ExecuteReader(IEnumerable<ColumnBase> selectedColumns, IFilter where, Sort sort, IEnumerable<IJoin> joins, bool lockAllRows)
            {
                return new myRowsReader(_source.ExecuteReader(selectedColumns, where, sort, joins, false), this);
            }
            class myRowsReader : IRowsReader
            {
                IRowsReader _source;
                myRowsSource _parent;
                public myRowsReader(IRowsReader source, myRowsSource parent)
                {
                    _source = source;
                    _parent = parent;
                }

                public void Dispose()
                {
                    _source.Dispose();
                }

                public IRow GetJoinedRow(Firefly.Box.Data.Entity e, IRowStorage c)
                {
                    var originalRow = _source.GetJoinedRow(e, c);
                    if (originalRow == null)
                        return null;
                    return new myRow(originalRow, c, e, _parent);
                }

                public IRow GetRow(IRowStorage c)
                {
                    return new myRow(_source.GetRow(c), c, _parent._entity, _parent);
                }

                public bool Read()
                {
                    return _source.Read();
                }
            }
            class myRow : IRow
            {
                internal IRow _row;
                IRowStorage _storage;
                Firefly.Box.Data.Entity _e;
                myRowsSource _parent;
                public myRow(IRow source, IRowStorage storage, Firefly.Box.Data.Entity e, myRowsSource parent)
                {
                    _parent = parent;
                    _row = source;
                    _storage = storage;
                    _e = e;
                }

                public void Delete(bool verifyRowHasNotChangedSinceLoaded)
                {
                    InitLockString();
                    _parent._parent._activeTransaction.Update(_dbLockString, _parent._parent);
                    _row.Delete(verifyRowHasNotChangedSinceLoaded);
                    if (_lockCounter > 0)
                        Unlock();
                }

                public bool IsEqualTo(IRow row)
                {
                    if (row == null)
                        return _row.IsEqualTo(null);
                    return _row.IsEqualTo(((myRow)row)._row);

                }

                string _dbLockString = "";
                int _lockCounter = 0;
                public void Lock()
                {
                    InitLockString();
                    _lockCounter++;
                    ReloadData();
                    _parent._parent._lockProvider.DoLock(_dbLockString, false, _parent._parent.CreateCommand, false);
                    _parent._lockedRows.Add(this);
                }

                private void InitLockString()
                {
                    if (_dbLockString == "")
                    {
                        var sb = new StringBuilder();
                        sb.Append(_e.EntityName);
                        foreach (var column in _e.PrimaryKeyColumns)
                        {
                            var s = new mySaver();
                            _storage.GetValue(column).SaveTo(s);
                            sb.Append(",");
                            sb.Append(s.result);
                        }
                        _dbLockString = sb.ToString();
                    }
                }

                class mySaver : IValueSaver
                {
                    public string result = "null";
                    public void SaveInt(int value)
                    {
                        result = value.ToString();
                    }

                    public void SaveDecimal(decimal value, byte precision, byte scale)
                    {
                        result = value.ToString(CultureInfo.InvariantCulture);
                    }

                    public void SaveString(string value, int length, bool fixedWidth)
                    {
                        if (value == null)
                            return;
                        else
                            result = value.TrimEnd(' ').Replace(",", ",,");
                    }

                    public void SaveAnsiString(string value, int length, bool fixedWidth)
                    {
                        if (value == null)
                            return;
                        else
                            result = value.TrimEnd(' ').Replace(",", ",,");
                    }

                    public void SaveNull()
                    {
                        return;
                    }

                    public void SaveDateTime(DateTime value)
                    {
                        result = value.ToString();
                    }

                    public void SaveTimeSpan(TimeSpan value)
                    {
                        result = value.ToString();
                    }

                    public void SaveBoolean(bool value)
                    {
                        result = value ? "1" : "0";
                    }

                    public void SaveByteArray(byte[] value)
                    {
                        foreach (var b in value)
                        {
                            result += (char)b;
                        }
                        result = result.Replace(",", ",,");
                    }

                    public void SaveEmptyDateTime()
                    {
                        result = "EmptyDate";
                    }
                }

                public void ReloadData()
                {
                    _row.ReloadData();
                }

                public void Unlock()
                {

                    _lockCounter--;
                    _parent._parent._activeTransaction.Unlock(_dbLockString, _parent._parent);

                    _parent._lockedRows.Remove(this);

                }

                public void Update(IEnumerable<ColumnBase> columns, IEnumerable<IValue> values, bool verifyRowHasNotChangedSinceLoaded)
                {
                    InitLockString();
                    _parent._parent._activeTransaction.Update(_dbLockString, _parent._parent);
                    _row.Update(columns, values, verifyRowHasNotChangedSinceLoaded);
                }

                public string GetLockedIdentifier()
                {
                    return _dbLockString;
                }
            }

            public IRow Insert(IEnumerable<ColumnBase> columns, IEnumerable<IValue> values, IRowStorage storage, IEnumerable<ColumnBase> selectedColumns)
            {
                return new myRow(_source.Insert(columns, values, storage,selectedColumns), storage, _entity, this);
            }

            public bool IsOrderBySupported(Sort sort)
            {
                return _source.IsOrderBySupported(sort);
            }
        }

        public bool SupportsTransactions
        {
            get { return _useTransactions; }
        }

        public void Truncate(Firefly.Box.Data.Entity entity)
        {
            ((IEntityDataProvider)_source).Truncate(entity);
        }


        public ISQLEntityDataProvider GetDecorated()
        {
            return _source;
        }

        public IValueLoader GetDataReaderValueLoader(IDataReader reader, int columnIndexInSelect, IDateTimeCollector dtc)
        {
            return _source.GetDataReaderValueLoader(reader, columnIndexInSelect, dtc);
        }
    }

    public class OracleLockProvider : NoTransactionEntityDataProvider.LockProvider
    {
        static Dictionary<string, int> _rowsThatDoNotNeedRelease = new Dictionary<string, int>();
        public void DoLock(string key, bool release, Func<IDbCommand> createCommand, bool keepLockForTransaction)
        {
            if (release)
            {
                int numOfLocks;
                if (_rowsThatDoNotNeedRelease.TryGetValue(key, out numOfLocks))
                {
                    if (numOfLocks > 0)
                    {
                        if (numOfLocks > 1)
                            _rowsThatDoNotNeedRelease[key]--;
                        else
                            _rowsThatDoNotNeedRelease.Remove(key);

                        return;
                    }
                }
            }
            using (var c = createCommand())
            {
                c.CommandType = CommandType.Text;
                var lockKey = c.CreateParameter();
                lockKey.ParameterName = ":lockKey";
                lockKey.Direction = ParameterDirection.Input;
                lockKey.Value = key;
                lockKey.DbType = DbType.AnsiString;
                lockKey.Size = 200;
                c.Parameters.Add(lockKey);
                var returnValue = c.CreateParameter();
                returnValue.ParameterName = ":returnValue";
                returnValue.DbType = DbType.Int32;
                returnValue.Direction = ParameterDirection.InputOutput;
                returnValue.Value = 0;
                c.Parameters.Add(returnValue);

                var lockHandle = c.CreateParameter();
                lockHandle.ParameterName = ":lockHandle";
                lockHandle.DbType = DbType.AnsiString;
                lockHandle.Size = 200;
                lockHandle.Value = "";
                lockHandle.Direction = ParameterDirection.InputOutput;
                c.Parameters.Add(lockHandle);

                c.CommandText = "begin\n" +
                                "dbms_lock.allocate_unique(:lockKey, :lockHandle );\n" +
                                (release ?
                                ":returnValue := dbms_lock.Release (:lockHandle );\n"
                                :
                                ":returnValue := dbms_lock.REQUEST (:lockHandle ,6,0);\n") +
                                "end;";
                c.ExecuteNonQuery();
                int r = (int)returnValue.Value;
                if (r == 0)
                    return;

                if (r == 1)
                    throw new DatabaseErrorException(DatabaseErrorType.LockedRow);
                if (r == 4)
                {
                    if (!_rowsThatDoNotNeedRelease.ContainsKey(key))
                        _rowsThatDoNotNeedRelease.Add(key, 1);
                    else
                        _rowsThatDoNotNeedRelease[key]++;
                }
                else
                    throw new Exception("Unexpected oracle lock result " + r);

            }
        }

        public SqlScriptTableCreator CreateScriptGeneratorTable(Firefly.Box.Data.Entity entity)
        {
            return new OracleTable(entity.EntityName);
        }
    }
    public class SQLServerLockProvider : NoTransactionEntityDataProvider.LockProvider
    {

        public void DoLock(string key, bool release, Func<IDbCommand> createCommand, bool keepLockForTransaction)
        {

            using (var c = createCommand())
            {
                c.CommandType = CommandType.StoredProcedure;
                var Resource = c.CreateParameter();
                Resource.ParameterName = "@Resource";
                Resource.DbType = DbType.String;
                Resource.Size = 255;
                Resource.Value = key;
                c.Parameters.Add(Resource);


                var LockOwner = c.CreateParameter();
                LockOwner.ParameterName = "@LockOwner";
                LockOwner.DbType = DbType.String;
                LockOwner.Value = keepLockForTransaction ? "Transaction" : "Session";
                LockOwner.Size = 32;

                c.Parameters.Add(LockOwner);
                if (release)
                {
                    c.CommandText = "sp_releaseapplock";
                }
                else
                {
                    var LockMode = c.CreateParameter();
                    LockMode.ParameterName = "@LockMode";
                    LockMode.Size = 32;
                    LockMode.DbType = DbType.String;
                    LockMode.Value = "Exclusive";
                    c.Parameters.Insert(1, LockMode);

                    var LockTimeout = c.CreateParameter();
                    LockTimeout.ParameterName = "@LockTimeout";
                    LockTimeout.DbType = DbType.Int32;
                    LockTimeout.Value = 0;
                    c.Parameters.Add(LockTimeout);
                    c.CommandText = "sp_getapplock";
                }

                var returnValue = c.CreateParameter();
                returnValue.ParameterName = "@returnVal";
                returnValue.Direction = ParameterDirection.ReturnValue;
                returnValue.DbType = DbType.Int32;
                c.Parameters.Add(returnValue);

                c.ExecuteNonQuery();
                if ((int)returnValue.Value < 0)
                    throw new DatabaseErrorException(DatabaseErrorType.LockedRow);
            }
        }

        public SqlScriptTableCreator CreateScriptGeneratorTable(Firefly.Box.Data.Entity entity)
        {
            return new MssqlTable(entity.EntityName, entity);
        }
    }

    public class DummyLockProvider : NoTransactionEntityDataProvider.LockProvider
    {
        public void DoLock(string key, bool release, Func<IDbCommand> createCommand, bool keepLockForTransaction)
        {

        }

        public SqlScriptTableCreator CreateScriptGeneratorTable(Firefly.Box.Data.Entity entity)
        {
            return new MssqlTable(entity.EntityName, entity);
        }
    }

}
