using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Department</summary>
    public class Department_ : ENV.UI.CustomHelp 
    {
        public Department_()
        {
            Caption = "Department";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Department Code: Two digit code for
department.

Description: The name of the department.

Report Indicator:(Y)es or (N)o to report
on the department.

Forward Cover: Number of days required
for ordering stock for department.

High Price: Highest price limit for
department.

Low Price: Lowest price limit.

Margin % :

Markup % :

Tax Type : Two digit tax code applicable
to department.
";
        }
    }
}
