using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Release Notes (Ver 3.02.00)</summary>
    public class ReleaseNotes_Ver3_02_00 : ENV.UI.CustomHelp 
    {
        public ReleaseNotes_Ver3_02_00()
        {
            Caption = "Release Notes (Ver 3.02.00)";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = 
@"BOXER CASH & CARRY :MERCHANDISING SYSTEM
                                        
(version 3.02) : 19/06/97

1. What's new in this version/release?

1.1 Promotion Download Date
The Promotion will be downloaded
for H/O to the store on this date

1.2 Promotion Enquiry
1.2.1 Select Promotion No
1.2.2 Promotions starting and
ending between selected
dates.

1.3 Supplier Branch Link
This will enable suppliers to be
de-linked per branch by the H/O
buyers.

1.4 Current Price Enquiry
Price Detail for a effective Date

1.5 Stock Request
Scroll facility on Stock Request
Lines.
";
        }
    }
}
