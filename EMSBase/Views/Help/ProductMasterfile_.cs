using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Product Masterfile</summary>
    public class ProductMasterfile_ : ENV.UI.CustomHelp 
    {
        public ProductMasterfile_()
        {
            Caption = "Product Masterfile";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"A Product by defination is grouping of
items by virtue of their common identity
eg. BILL'S TEA 500g.
The product code is self generating with
a maximum of five digits.
Each product will have one or more
variants, the default being the variant
with code zero, called the 'Master'. The
variant code is self generating with a
maximum of two digits.
eg. BILL'S LEMON TEA, BILL'S TAGLESS TEA
BAGS, etc.

On creation of a new product, the 'Maste
r' variant is created automatically.
The ITEM is created by combining the
product code with the variant code and
applying a check digit, to give a ITEM
Code (maximum of 8 digits).

Once an ITEM is created, the program
will prompt for other critical data that
is associated with the new item, i.e.
Range/s, Supplier/s, Stock per Branch,
Price per Supplier, Bin Locations per
Branch, EAN numbers.

NOTE: Each item MUST have a range, a
supplier and a price on creation!!
";
        }
    }
}
