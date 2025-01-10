using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>--------BUSINESS RULES--------</summary>
    public class _BUSINESS_RULES_ : ENV.UI.CustomHelp 
    {
        public _BUSINESS_RULES_()
        {
            Caption = "--------BUSINESS RULES--------";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = "";
        }
    }
}
