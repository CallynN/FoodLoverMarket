using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Price Verification</summary>
    public class PriceVerification : ENV.UI.CustomHelp 
    {
        public PriceVerification()
        {
            Caption = "Price Verification";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(5, 26);
            Size = new Size(395, 273);
            SystemMenu = false;
            Text = 
@"Price Verication is basically a three step process.
viz. 1. Send Current Prices of Items to Scanner
2. Scan Items in Store and punch in prices on scanner
3. Recieve scanned prices from scanner and produce a report
highlighting any discrepencies.

Step 1: Downloading Prices to Scanner
This can be done in 1 of 3 ways
ie. - Send items for a single supplier only
- Send items for 1 department only
- Send all items
(NB: The more items you send the more scanning is to be done)


Step 2: Scan Items in Store
Use the up and down cursor arrows to select price verification
and then press enter to activate this option.
Each time an item is scanned the operator is given 3 attempts
to type in the correct price of the item.
If after the 3rd attempt the operator fails to enter the correct
price, then the last INCORRECT price entered is stored.
If items are scanned for which the price does not exist on the
SCANNER, the bar code and price of the item are stored.
Once all the items have been scanned the operator must press
FUNC (green button on scanner) +  F9  to begin processing.
(NB: Items not scanned, will print on the report as 'Not Scanned'
and not as an incorrect price)


Step 3: Recieve Prices from Scanner
The Recieve Scanned Prices program does 3 things viz.
Firstly,
It Recieves scan data from the scanner and stores it in a file
with the prefix PRI (this file name must be recorded because it
is essential for the next step)
Secondly,
It Imports the PRI file into a Magic Database File.
(It is at this step that the PRI file name is requested)
Thirdly, and finally
It produces a report on the price scan highlighting prices that
differ, items not scanned and items not found.
";
        }
    }
}
