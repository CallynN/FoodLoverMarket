using ENV;
using ENV.Utilities;
using Firefly.Box;
namespace EMS
{
    public class Program
    {
        [System.STAThread]
        public static void Main(string[] args)
        {
            try
            {
                //
                Init(args);
                //Start if statement for Relex Service
                if (!System.Environment.UserInteractive)
                {
                   // System.ServiceProcess.ServiceBase.Run(new RelexService());
                    return;
                }
                //End if statement for Relex Service

                ENV.UserSettings.ShowSplashScreen();
                /**/
                ProcessIdentifier.GetSession();

                Housekeeping housekeep = new Housekeeping();
                housekeep.HomeDrive();
                /**/
                ApplicationCore.Run();
                ENV.UserSettings.FinalizeINI();
               
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e, "TOTAL CRASH");
                System.Environment.ExitCode = 1;
                ENV.Common.ShowExceptionDialog(e);
            }
        }
        public static void Init(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            
            Text.StopProcessingFormatOnCharF = true;
            ENV.UserSettings.AsyncComEvents = true;
            ENV.Common.SetAsCaseInsensitive();
            ENV.Data.DataProvider.NoTransactionEntityDataProvider.Init();


            ENV.Data.DataProvider.OracleHelper.UseOracleODPClient("DD/MM/YY", "BINARY", ".,");
            
            ENV.Commands.SetDefaultKeyboardMapping();
            ENV.Commands.SetVersion9CompatibleKeyMapping();
            ENV.Common.ApplicationTitle = "EMS";
            ENV.UserSettings.FixedBackColorInNonFlatStyles = true;
            ENV.UserSettings.InitUserSettings("EMS.ini", args);

            UserMethods u = new UserMethods();
            if (u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseEnabled").ToUpper().Trim() == "Y")
            {
                ENV.Data.DataProvider.ConnectionManager.Shared.AddMicrosoftSQLDatabase("EMSMSSQL", u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLDatabaseName").Trim(), u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLServerName").Trim(), u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLUsername").Trim(), u.IniGet("[MAGIC_LOGICAL_NAMES]MSSQLSPassword").Trim(), System.Data.IsolationLevel.ReadCommitted);
                ENV.Data.OracleEntity.SwitchToSQL();
            }
        }
    }
}
