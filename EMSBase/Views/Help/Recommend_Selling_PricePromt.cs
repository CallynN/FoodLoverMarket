using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Recommend_Selling_Price Promt</summary>
    public class Recommend_Selling_PricePromt : ENV.UI.CustomHelp 
    {
        public Recommend_Selling_PricePromt()
        {
            Caption = "Recommend_Selling_Price Promt";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = "";
        }
    }
}
