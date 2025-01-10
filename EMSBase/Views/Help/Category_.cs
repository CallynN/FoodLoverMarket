using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Category</summary>
    public class Category_ : ENV.UI.CustomHelp 
    {
        public Category_()
        {
            Caption = "Category";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Category Code : Two digit code to
indentify the Category.

Description : The description of the
category eg. Known Value Items,
Basic Lines.
";
        }
    }
}
