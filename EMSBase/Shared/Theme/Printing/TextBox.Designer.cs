namespace EMS.Shared.Theme.Printing
{
    partial class TextBox
    {
        void InitializeComponent()
        {
            FontScheme = new EMS.Shared.Theme.Fonts.DefaultTableEditField();
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultPrintFormColor();
            Style = Firefly.Box.UI.ControlStyle.Flat;
            Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            RightToLeftLayout = false;
            AbsoluteBindTop = true;
            RightToLeftByFormat = false;
        }
    }
}
