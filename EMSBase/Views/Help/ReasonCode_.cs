using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Reason Code</summary>
    public class ReasonCode_ : ENV.UI.CustomHelp 
    {
        public ReasonCode_()
        {
            Caption = "Reason Code";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Reason Code: Two digit code to identify
the reason.

Description: Description for reason code
";
        }
    }
}
