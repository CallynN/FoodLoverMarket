using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Item Supplier</summary>
    public class ItemSupplier : ENV.UI.CustomHelp 
    {
        public ItemSupplier()
        {
            Caption = "Item Supplier";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"An ITEM can be supplied by on or more
Suppliers (identified by supplier codes)

Zoom on the Supplier field for selection
of suppliers.

Supplier Product Code : The supplier's
stock code for the ITEM.

Economic Order Qty : The quantity used
for auto ordering system.

Line Disounts : Default Trade discounts
given by the supplier for the Item in
terms of percentages or actual values.

Special Prices : A 'Y' (yes) indicator
implies that supplier offers various
cost prices for the item for different
branches.
";
        }
    }
}
