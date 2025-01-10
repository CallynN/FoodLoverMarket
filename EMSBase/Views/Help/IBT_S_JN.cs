using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>IBT&apos;S (JN)</summary>
    public class IBT_S_JN : ENV.UI.CustomHelp 
    {
        public IBT_S_JN()
        {
            Caption = "IBT'S (JN)";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(5, 26);
            Size = new Size(390, 273);
            SystemMenu = false;
            Text = 
@"A. Creation of an IBT
---------------------
UNIT & CASES
Stock Update
The stock quantity in the stock file is reduced by the qty
of the IBT
Reduce Stock Value by Total Cost as determined by Stock FIFO
Cost Values (ie. Total Cost of each IBT line)
Stock FIFO Update
The cost of the IBT item is calculated using the Stock FIFO
file for that item.
The varying costs based on different receipt dates is accumulated
and the average cost is calculated & stored as the IBT cost.
The Stock_Sold in the Stk_FIFO is reduced to reflect stock moved.
";
        }
    }
}
