using System.Drawing;
namespace EMS.Views.Help
{
    public class Untitled : ENV.UI.CustomHelp 
    {
        public Untitled()
        {
            Border = Firefly.Box.UI.ControlBorderStyle.None;
            Caption = "";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(110, 234);
            Size = new Size(170, 26);
            SystemMenu = false;
            Text = 
@"       BOXER CASH & CARRY        
 Alt+C Calculator Alt+L Calender 
";
            TitleBar = false;
        }
    }
}
