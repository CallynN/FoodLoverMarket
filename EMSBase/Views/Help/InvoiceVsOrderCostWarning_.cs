using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Invoice vs Order Cost Warning</summary>
    public class InvoiceVsOrderCostWarning_ : ENV.UI.CustomHelp 
    {
        public InvoiceVsOrderCostWarning_()
        {
            Caption = "Invoice vs Order Cost Warning";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = "";
        }
    }
}
