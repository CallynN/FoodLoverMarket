using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Variant Masterfile</summary>
    public class VariantMasterfile : ENV.UI.CustomHelp 
    {
        public VariantMasterfile()
        {
            Caption = "Variant Masterfile";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"A Variant is a sub-product; the variant
code together with the product code and
check digit form the ITEM code.
The variant code is self generating with
a maximum of two digits.
Each product will have one or more
variants, the default being the variant
with code zero, called the 'Master'.
eg. PRODUCT  = BILL'S TEA 500g
VARIANT  = BILL'S LEMON TEA
";
        }
    }
}
