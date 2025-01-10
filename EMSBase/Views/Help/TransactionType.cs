using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Transaction Type</summary>
    public class TransactionType : ENV.UI.CustomHelp 
    {
        public TransactionType()
        {
            Caption = "Transaction Type";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Transaction Code: Two digit code to
identify the transaction.

Description : Identify the type of
transaction eg. Sale, Return, etc.
";
        }
    }
}
