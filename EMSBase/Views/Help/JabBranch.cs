using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Jab Branch</summary>
    public class JabBranch : ENV.UI.CustomHelp 
    {
        public JabBranch()
        {
            Caption = "Jab Branch";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 156);
            SystemMenu = false;
            Text = 
@"
F3 - Delete Branch
F4 - Insert New Branch

Shift + F5 - Show Items
";
        }
    }
}
