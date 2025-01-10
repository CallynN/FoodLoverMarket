using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Telephone</summary>
    public class Telephone_ : ENV.UI.CustomHelp 
    {
        public Telephone_()
        {
            Caption = "Telephone";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Telephone Code: Code to identify the
telephone. Use for both branch
and suppliers; size - 6 alpha.

Telephone Type : Type of phone number
F - Fax, B - Business, H - Home,
M - Modem.

Person : Name of person.

Dialing Code : Town/City dialing code.

Telephone Number : Actual telephone
number.

Telephone Extension : switchboard
extension number.
";
        }
    }
}
