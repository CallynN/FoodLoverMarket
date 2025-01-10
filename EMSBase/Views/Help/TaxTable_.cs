using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Tax Table</summary>
    public class TaxTable_ : ENV.UI.CustomHelp 
    {
        public TaxTable_()
        {
            Caption = "Tax Table";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Tax Type: Two digit code to identify
the tax type.

Description: Identification of tax type.

Rate % : Perentage taxation for type.

Input Output Indicator: (I)nput or (O)ut
put for incoming tax or outgoing tax.
";
        }
    }
}
