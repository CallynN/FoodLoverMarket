using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>SANA EAN (JN)</summary>
    public class SANA_EAN_JN_ : ENV.UI.CustomHelp 
    {
        public SANA_EAN_JN_()
        {
            Caption = "SANA EAN (JN)";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(5, 26);
            Size = new Size(395, 273);
            SystemMenu = false;
            Text = 
@"Blank9
Prefix - 2499    = 14 digit EAN code
Zero Filled Item Code9(10)
Check Digit9

Check Digit is calculated based on the SANA algorithm for a 13 digit
EAN code.
";
        }
    }
}
