using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Branch</summary>
    public class Branch : ENV.UI.CustomHelp 
    {
        public Branch()
        {
            Caption = "Branch";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Branch No. : Two digit code indentifying
the BRANCH.

Branch_Name: The name of the BRANCH.

Range : Two digit code for the item
range.

Region : Two digit code for the region
in S.A.

Manager : The name of the BRANCH manager
";
        }
    }
}
