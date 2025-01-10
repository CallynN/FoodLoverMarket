namespace EMS.Shared.Theme.Controls
{
    partial class ListBox
    {
        void InitializeComponent()
        {
            AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0,0,0,0);
            AbsoluteBindTop = true;
            Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            RightToLeftLayout = false;
            FontScheme = new EMS.Shared.Theme.Fonts.DefaultTableEditField();
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultEditField();
            Border = Firefly.Box.UI.ControlBorderStyle.Thin;
        }
    }
}
