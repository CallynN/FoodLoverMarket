using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>-------Key help--------------</summary>
    public class _KeyHelp : ENV.UI.CustomHelp 
    {
        public _KeyHelp()
        {
            Caption = "-------Key help--------------";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = "";
        }
    }
}
