using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Sub-Department</summary>
    public class Sub_Department_ : ENV.UI.CustomHelp 
    {
        public Sub_Department_()
        {
            Caption = "Sub-Department";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Department Code: Two digit code to
identify the department to which the
sub belongs.

Sub-Department: Two digit code for the
sub-department.

Description: Description for the sub-
department.
";
        }
    }
}
