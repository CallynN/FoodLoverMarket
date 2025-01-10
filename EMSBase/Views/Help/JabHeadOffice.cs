using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Jab Head Office</summary>
    public class JabHeadOffice : ENV.UI.CustomHelp 
    {
        public JabHeadOffice()
        {
            Caption = "Jab Head Office";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = 
@"


F5 - Zooom to branches
";
        }
    }
}
