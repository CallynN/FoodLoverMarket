using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Release Notes (Ver 3.01)</summary>
    public class ReleaseNotes_Ver3_01 : ENV.UI.CustomHelp 
    {
        public ReleaseNotes_Ver3_01()
        {
            Caption = "Release Notes (Ver 3.01)";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = 
@"BOXER CASH & CARRY :MERCHANDISING SYSTEM
                                        
(version 3.01) : 15/04/97

1. What's new in this version/release?

1.1 Imprest
1.2 Scale Items
1.3 Price Flag
1.3.1 Orders
1.3.2 Goods Check-In
1.3.3 GRV
1.3.4 Future Price Reports
1.4 POS
1.4.1 Button for multiple EAN's
on POS Price Review.
1.4.2 Selection Per Supplier for
POS Price Review Report.
1.5 SALES
1.5.1 Selection of Supplier and
Sub Department on Sales
Enquiry.
1.6 PRICING
1.6.1 Latest Sell in List Price
Enquiry.
";
        }
    }
}
