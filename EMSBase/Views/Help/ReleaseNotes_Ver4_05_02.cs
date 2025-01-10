using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Release Notes (Ver 4.05.02)</summary>
    public class ReleaseNotes_Ver4_05_02 : ENV.UI.CustomHelp 
    {
        public ReleaseNotes_Ver4_05_02()
        {
            Caption = "Release Notes (Ver 4.05.02)";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(75, 143);
            Size = new Size(210, 273);
            Text = 
@"This is a test of the Help Menu
";
        }
    }
}
