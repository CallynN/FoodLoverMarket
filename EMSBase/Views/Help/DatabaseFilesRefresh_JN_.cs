using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Database Files Refresh (JN)</summary>
    public class DatabaseFilesRefresh_JN_ : ENV.UI.CustomHelp 
    {
        public DatabaseFilesRefresh_JN_()
        {
            Caption = "Database Files Refresh (JN)";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(5, 26);
            Size = new Size(395, 273);
            SystemMenu = false;
            Text = 
@"
1. Press <Shift>+<F10> to export files from database
2. The main entries should be as follows

Operation        Export
TypeFiles
FormatInternal
File Name        ./pofiles (in lowercase)

3. Once this is completed the refresh database program should be executed.
";
        }
    }
}
