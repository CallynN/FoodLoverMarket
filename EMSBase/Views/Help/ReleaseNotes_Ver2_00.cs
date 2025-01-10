using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Release Notes (Ver 2.00)</summary>
    public class ReleaseNotes_Ver2_00 : ENV.UI.CustomHelp 
    {
        public ReleaseNotes_Ver2_00()
        {
            Caption = "Release Notes (Ver 2.00)";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = 
@"BOXER CASH & CARRY :MERCHANDISING SYSTEM
                                        
(version 2.00) : 12/07/96

1. What's new in this version/release?
1.1 Module enhancements :
1.1.1 Deals
1.1.2 Promotions
1.1.3 IBT's & fifo
1.1.4 CCV's & fifo
1.2 New Modules :
1.2.1 POS Download
1.2.2 Stock Requests
1.3 Amendments :
1.3.1 Item Product Case pack now
numeric 4.
1.3.2 EAN validation : excluding
UPC codes.
1.3.3 Invoice cost on GRV Line
1.3.4 Default price change set
effective date to current
date + 2.
1.4 New Reports :
1.4.1 Item Master by Category.
1.4.2 Current Price by Category.
1.4.3 Sell Price Lower/Greater
than Recommended Sell for
Orders Placed/Received.



CHANGES AFTER VERSION 2

1. Prog 198. Print G.R.V WorkSheet
Cater for a range of Delivery No.'s ,
Replace GRV_Sell_Price with Unit_Sell
Price (Current Sell Price) 25/07/96

Transmited to all Branches but
Warehouse (JS 25/07/96)

2. Prog 755. Extract POS Review
Rebuild Key 7 of File 13(Price)

Transmitted to R/Bay only (TE 25/07/96)

3. Prog 617. GRV Amend
Zeroise all QTY and weight and not
only the ones that had been modified.

Update Cost_Price with Cost_Price
where cost_Prise is updated and
Invoice_Cost is Lower.

Transmited to stn016   (JS 29/07/96)

4. Prog 196. Maintain GRV Voucher
Prevent Update with 0 Cost_Price

Transmitted to mtu017  (JS 29/07/96)

5. Prog 617. Amend G.R.V
Amend prog such that all Quantities
are zeroised without physicaly
tabbing through records.

6. Prog 590 + 591
Amend Recalc Order such that unit Cos
t column shows unit cost and not case
cost

Transmitted to all    (JS 01/08/96)

7. Prog 908. EANS : Supplier
List store numbers as part of heading
(JS 31/07/96)

8. Sales File(60) - Update Keys
Up_POS_File (152 - Update File Layout

9. Prog 446 - Query Item Supp by EAN
Include second parm = 'N' on calling
Prog 456

10. Prog 88 & 436 - Price Changes
(DM 07/08/96)

11. Prog 447 - Query Item Supplier
Include 3rd & 4th parm on calling
(JS 07/08/96)

12. Prog 68 - Maintain Item MasterFile
Replace Item_Status with correct
field (JS 08/08/96)

13. Prog 215 - Maintain Tax Invoice
Update CCV Date with current date if
CCV Modified. (JS 08/08/96)

14. Prog 448 - Query Item MasterFile
include parms to access Supplier
Info. through buttons. (JS 08/08/96)

15. Prog 666 - Include Quantity Totals
(JS 15/08/96)

16. Update File 60 - Sale with one
unique key

17. Update File 146 - Up_Sale_trans
Substitute Transmission_Date with
Sale_Date in keys.

18. Update File 152 - Up_POS
Include item_no and key 2
(JS 15/08/96)

19. All Sales Programs Redone.

20. Prog 831 - Relocate 'Date From > To'
message

(BD 20/08/96)
";
        }
    }
}
