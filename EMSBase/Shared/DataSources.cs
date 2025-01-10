using ENV;
using ENV.Data.DataProvider;
namespace EMS.Shared
{
    public class DataSources
    {
        public static DynamicSQLSupportingDataProvider Untitled 
        {
            get
            {
                return ConnectionManager.GetSQLDataProvider("");
            }
        }
        public static DynamicSQLSupportingDataProvider Oracle7 
        {
            get
            {
                UserMethods u = new UserMethods();
                //var a = u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseEnabled");
                if (u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseEnabled").ToUpper().Trim() == "Y")
                {
                    return ConnectionManager.GetSQLDataProvider("EMSMSSQL");
                }
                else
                {
                    return ConnectionManager.GetSQLDataProvider("Oracle7");
                }
            }
        }
        public static DynamicSQLSupportingDataProvider Oracle7NoTransaction
        {
            get
            {
                UserMethods u = new UserMethods();
                //var a = u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseEnabled");
                if (u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseEnabled").ToUpper().Trim() == "Y")
                {
                    return ConnectionManager.GetNoTransactionSQLDataProvider("EMSMSSQL");
                }
                else
                {
                    return ConnectionManager.GetNoTransactionSQLDataProvider("Oracle7");
                }
            }
        }
        public static Firefly.Box.Data.DataProvider.IEntityDataProvider Memory 
        {
            get
            {
                return MemoryDatabase.Instance;
            }
        }
        public static DynamicSQLSupportingDataProvider oracle 
        {
            get
            {
                UserMethods u = new UserMethods();
                //var a = u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseEnabled");
                if (u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseEnabled").ToUpper().Trim() == "Y")
                {
                    return ConnectionManager.GetSQLDataProvider("EMSMSSQL");
                }
                else
                {
                    return ConnectionManager.GetSQLDataProvider("oracle");
                }
            }
        }
        public static Firefly.Box.Data.DataProvider.IEntityDataProvider DefaultDatabase 
        {
            get
            {
                return BtrieveMigration.GetDataProvider("Default Database");
            }
        }
    }
}
