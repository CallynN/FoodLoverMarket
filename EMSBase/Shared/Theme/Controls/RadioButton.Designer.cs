namespace EMS.Shared.Theme.Controls
{
    partial class RadioButton
    {
        void InitializeComponent()
        {
            FontScheme = new EMS.Shared.Theme.Fonts.RadioButtonDefaultFont();
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultEditField();
            AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0,0,0,0);
            FixedBackColorInNonFlatStyles = true;
            Border = Firefly.Box.UI.ControlBorderStyle.Thin;
            Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            Style = Firefly.Box.UI.ControlStyle.Raised;
            RightToLeftLayout = false;
            ForceFixedColumnWidth = true;
        }
    }
}
