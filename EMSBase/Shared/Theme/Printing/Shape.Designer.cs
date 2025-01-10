namespace EMS.Shared.Theme.Printing
{
    partial class Shape
    {
        void InitializeComponent()
        {
            FontScheme = new EMS.Shared.Theme.Fonts.DefaultTableEditField();
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultPrintFormColor();
            Style = Firefly.Box.UI.ControlStyle.Flat;
            Alignment = System.Drawing.ContentAlignment.TopLeft;
            RightToLeftLayout = false;
            AbsoluteBindTop = true;
        }
    }
}
