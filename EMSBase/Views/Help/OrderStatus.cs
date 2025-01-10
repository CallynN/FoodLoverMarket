using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Order Status</summary>
    public class OrderStatus : ENV.UI.CustomHelp 
    {
        public OrderStatus()
        {
            Caption = "Order Status";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Status Code : Code indentifying status,
two alpha in size.

Description : The description of the
status eg,. placed, delivered,
balanced,normal.
";
        }
    }
}
