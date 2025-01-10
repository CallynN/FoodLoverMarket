namespace EMS.Shared.Theme.Controls
{
    partial class CheckBox
    {
        void InitializeComponent()
        {
            AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0,0,0,0);
            FontScheme = new EMS.Shared.Theme.Fonts.DefaultTableEditField();
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultEditField();
            Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            RightToLeftLayout = false;
            ColumnChangeWhileFocusedForcesRowChange = true;
            CheckBoxPadding = true;
            WidthByFontWhenRightAligned = true;
            ForceBlackCheckmarkOnFlatStyles = true;
            DrawDisabledCheckboxAsNormal = true;
        }
    }
}
