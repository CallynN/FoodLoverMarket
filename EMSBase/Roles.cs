using ENV.Security;
namespace EMS
{
    /// <summary>Roles</summary>
    public class Roles
    {
        /// <summary>Total Access</summary>
        public static readonly Role TotalAccess = new Role("Total Access", "HIGHACC");
        /// <summary>Head_Office_Maintenance_1</summary>
        public static readonly Role Head_Office_Maintenance_1 = new Role("Head_Office_Maintenance_1", "HOFFMAIN1");
        /// <summary>TableFullAccess</summary>
        public static readonly Role TableFullAccess = new Role("TableFullAccess", "FULLACCESS");
        /// <summary>TableReadOnly</summary>
        public static readonly Role TableReadOnly = new Role("TableReadOnly", "TABLEREAD");
        /// <summary>Administrator</summary>
        public static readonly Role.Administrator Administrator = new Role.Administrator("Administrator", "Administrator");
        /// <summary>UserManager</summary>
        public static readonly Role UserManager = new Role("UserManager", "UserManager", false);
        /// <summary>DeveloperTools</summary>
        public static readonly Role DeveloperTools = new Role("DeveloperTools", "DeveloperTools", false);



       


        

        
       

      







    }
}
