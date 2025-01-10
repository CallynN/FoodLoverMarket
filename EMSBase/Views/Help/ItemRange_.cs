using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Item Range</summary>
    public class ItemRange_ : ENV.UI.CustomHelp 
    {
        public ItemRange_()
        {
            Caption = "Item Range";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Each ITEM MUST belong to one or more
Ranges. Zoom on Range field for
selection.
The Range is essential for the creation
of Stock Item records for Branches. A
branch will carry one or more ranges.
";
        }
    }
}
