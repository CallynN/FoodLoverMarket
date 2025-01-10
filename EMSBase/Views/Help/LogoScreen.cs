using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>LogoScreen</summary>
    public class LogoScreen : ENV.UI.CustomHelp 
    {
        public LogoScreen()
        {
            Caption = "LogoScreen";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 0);
            Size = new Size(210, 273);
            Text = "";
        }
    }
}
