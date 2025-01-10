namespace EMS.Shared.Theme.Controls
{
    partial class CompatibleGrid
    {
        void InitializeComponent()
        {
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultWindow();
            FixedBackColorInNonFlatStyles = true;
            ActiveRowStyle = Firefly.Box.UI.GridActiveRowStyle.Border;
            DrawPartialRow = false;
            HorizontalScrollbar = false;
            WidthByColumns = true;
            UseVisualStyles = false;
            FixedFocusedTextboxForeColorInAlternatingRowColorStyle = true;
            UseControlAsActiveRowBackColorWhenStyleIsRowBackColorAndActiveRowColorSchemeWasNotSet = true;
            DrawPartialRowBehindScrollBar = false;
            MultiSelectRowStyle = Firefly.Box.UI.GridMultiSelectRowStyle.InvertedColors;
            UseDefaultBackColorForStandardStyleWithRowColorStyleByColumnAndControls = true;
            UseUpDownArrowKeysForControlNavigationIfThereIsOnlyOneVisibleRow = true;
        }
    }
}
