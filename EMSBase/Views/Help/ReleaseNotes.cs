using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Release Notes</summary>
    public class ReleaseNotes : ENV.UI.CustomHelp 
    {
        public ReleaseNotes()
        {
            Caption = "Release Notes";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = 
@"BOXER CASH & CARRY :MERCHANDISING SYSTEM
                                        
1. What's new in this version/release?
PAGE DOWN FOR PREVIOUS RELEASE INFO
(Version 4.02.03) : 02/12/1999
1.1  Customer Invoices
Selection of discount in
transaction.

(Version 4.02.00) : 25/06/1999
1.1  Pos Extract No for H/O Dayend.

1.2  RP1007 - MU/MD Floor Price
Exception.

1.3  RP309 - GRV/INV Matching.

1.4  Housekeeping on Branch Item.

1.5  Housekeeping on Promotions.

1.6  Promotion Media.

1.7  Non Price Scanning.

1.8  Grv Monthly Consolidation.

















(Version 4.01.00) : 28/01/1999
1.1  Cash & Banking

1.2  Stock on Hand Report - RP1152
By Dept/Cat or By Supplier.

1.3  Rate of Sale Calculation.

1.4  Replenishment System for
Scanning Stores.

1.5  GRV
1.5.1  Proforma GRV.
1.5.2  Amend GRV Process.

1.6  IBT Amend Process.

1.7  Download STOCKPRE.DAT to Scanner

1.8  Price Changes Effective on a
Wednesday.

1.9  Houskeeping
1.9.1  CCV'S
1.9.2  IBT'S

1.10 Supplier Invoices.

1.11 Customer Invoices.

1.12 Customer Credit Notes.

(Version 4.00.00) : 22/08/1998
1.1  GRV BATCH REPORT
1.1.1  By Buyer
1.1.2  Sub Totals for Department
Indicator 'Y' or 'N'.
1.1.3  Exception GRV Report -
Below Target GP %.

1.2  SELL PRICES
1.2.1  Sell Price Review by
Buyer.
1.2.2  Sell Price Changes only
effective on a Tuesday.
1.2.3  Sell Price Trace at H/O
in /u/spchange.
1.2.4  Different Effective Dates
for Cost and Sell Prices.

1.3  POS DOWNLOAD
1.3.1  Upload of MU/MD to H/O.
1.3.2  Download Batch No equal
to current date.
1.3.3  New Lines do not appear
under EAN section.

1.4  Year 2000 Compliant.

1.5  STOCKTAKE
1.5.1  Total per Bin.
1.5.2  Floor Sell.
1.5.3  Weight.
1.5.4  Bin Progress Enquiry.
1.5.5  Stocktake Procedures
control in dayend.

1.6  TRANSACTION BLOCKS
1.6.1  No amend of GRV,IBT and
CCV for last week after
the following Monday.
1.6.2  No amend of GRV,IBT and
CCV after stock freeze
date.

1.7  UTILITY'S
1.7.1  Backout Monthly Sales.

1.8  DAYEND PROCEDURES
1.8.1  Dayend Process control.
1.8.2  Prevent Duplication of
BRHEOD2.


(Version 3.07.00) : 10/06/1998
1.1  MU/MD Control in POS.

1.2  IBT Matching.

(Version 3.06.01) : 28/04/1998
1.1  Transmission Log Enquiry range
on Transmission Date not Date.

1.2  POS Price Review date stamped
with Transmission Date.

1.3  Once Off POS Extract to POS
Review for one or all Suppliers.

1.4  Import of TOTALS.DAT in Store
Dayend2.

1.5  Scale Report.

1.6  Termination of Discontinued
items in Store Dayend2.

1.7  Printing of Transmission Reports

1.8  Allow same item for multiple
suppliers on same promotion.

1.9  Discontinue of Branch Items in
Promotion Branch Item.

(Version 3.06.00) : 17/03/1998
1.1  KVI Per Branch.

1.2  SPM GP % by Category Calculation

1.3  Stocktake Reset modifications.

(Version 3.05.02) : 19/12/1997
1.1  Two Way Price Check.

1.2  Deal Selection in Order.

1.3  Scale Labels.

(Version 3.05.01) : 04/12/1997
1.1  Housekeeping on POS Review and
POS Journal.

1.2  Enquiry on POS Extract Checks.

1.3  Enquiry on Department Sales.

1.4  Purchase Order for B and C
Items.

1.5  Price Control Flag changes from
Y to N will download Current
Sell to Branches.

(Version 3.05.00) : 06/11/1997
1.1  Scanning and Non Scanning Store
identification for EAN extract.

1.2  Imprest Spot Counts.

1.3  Promotion Key Change.

1.4  Housekeeping on Daily, Weekly
and Monthly Sales.

1.5  Housekeeping on Promotions.
";
        }
    }
}
