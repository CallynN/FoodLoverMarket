using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Stock Masterfile</summary>
    public class StockMasterfile_ : ENV.UI.CustomHelp 
    {
        public StockMasterfile_()
        {
            Caption = "Stock Masterfile";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = "";
        }
    }
}
