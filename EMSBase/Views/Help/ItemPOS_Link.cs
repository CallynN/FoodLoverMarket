using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Item POS Link</summary>
    public class ItemPOS_Link : ENV.UI.CustomHelp 
    {
        public ItemPOS_Link()
        {
            Caption = "Item POS Link";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Item No. : Stock Item Code of 8 digits.

EAN No. : The Bar Code number of the
shrink wrap stock item.

Quantity : Number of units in the
shrink wrap pack.
";
        }
    }
}
