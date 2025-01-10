using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>LogoScreen iii</summary>
    public class LogoScreenIii : ENV.UI.CustomHelp 
    {
        public LogoScreenIii()
        {
            Border = Firefly.Box.UI.ControlBorderStyle.None;
            Caption = "LogoScreen iii";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(0, 273);
            Size = new Size(395, 39);
            SystemMenu = false;
            Text = 
@"                                                                              
 BOXER CASH & CARRY - WE WILL NOT BE BEATEN !!! 
                                                                              
";
            TitleBar = false;
        }
    }
}
