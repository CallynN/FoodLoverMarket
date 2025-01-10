using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Unit of Measure</summary>
    public class UnitOfMeasure_ : ENV.UI.CustomHelp 
    {
        public UnitOfMeasure_()
        {
            Caption = "Unit of Measure";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Coode : Two digit code for the unit.

Unit of Measure: Description eg. kg,
Lt.,cases, boxes, etc.
";
        }
    }
}
