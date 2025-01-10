using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Frequency</summary>
    public class Frequency : ENV.UI.CustomHelp 
    {
        public Frequency()
        {
            Caption = "Frequency";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Frequency Code: Two digit code for
frequency indentification.

Description: eg. Yearly, Monthly,
Half-yearly.
";
        }
    }
}
