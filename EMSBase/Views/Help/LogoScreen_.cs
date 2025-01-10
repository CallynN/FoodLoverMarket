using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>LogoScreen</summary>
    public class LogoScreen_ : ENV.UI.CustomHelp 
    {
        public LogoScreen_()
        {
            Border = Firefly.Box.UI.ControlBorderStyle.None;
            Caption = "LogoScreen";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(0, 273);
            Size = new Size(395, 39);
            SystemMenu = false;
            Text = 
@"                                                                              
 BOXER CASH & CARRY - WE WILL NOT BE BEATEN !!!Ver 3.01  
                                                                              
";
            TitleBar = false;
        }
    }
}
