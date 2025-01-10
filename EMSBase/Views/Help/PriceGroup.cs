using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Price Group</summary>
    public class PriceGroup : ENV.UI.CustomHelp 
    {
        public PriceGroup()
        {
            Caption = "Price Group";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Code : Two digit code identifying the
Price Group.

Amount : The selling price of all items
in the group.
";
        }
    }
}
