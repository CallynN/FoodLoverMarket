using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Release Notes(ver9.5)test</summary>
    public class ReleaseNotes_ver9_5_test : ENV.UI.CustomHelp 
    {
        public ReleaseNotes_ver9_5_test()
        {
            Caption = "Release Notes(ver9.5)test";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(75, 143);
            Size = new Size(210, 273);
            Text = "hgjh";
        }
    }
}
