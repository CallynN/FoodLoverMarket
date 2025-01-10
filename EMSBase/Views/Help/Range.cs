using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Range</summary>
    public class Range : ENV.UI.CustomHelp 
    {
        public Range()
        {
            Caption = "Range";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Range Code: Two digit code to identify
the range.

Description: A desription to identify
the merchandise that belong
to the range.
";
        }
    }
}
