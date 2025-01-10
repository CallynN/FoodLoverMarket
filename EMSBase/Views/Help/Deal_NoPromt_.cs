using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Deal_No Promt</summary>
    public class Deal_NoPromt_ : ENV.UI.CustomHelp 
    {
        public Deal_NoPromt_()
        {
            Caption = "Deal_No Promt";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = "";
        }
    }
}
