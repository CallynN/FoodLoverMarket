using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Address</summary>
    public class Address : ENV.UI.CustomHelp 
    {
        public Address()
        {
            Caption = "Address";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Address Prefix : Single alpha (S or B),
to identify either Supplier or
Branch address.

Address Code: Code to identify the
address.Used for both branch
and suppliers; size - 6 digits.


Address Type : Type of phone number
P - Postal, D - Delivery,
B - Business, A - Admin Office.

Address Lines 1,2,3,4 : The actual
address.

Postal Code : Zip Code.
";
        }
    }
}
