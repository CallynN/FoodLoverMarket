namespace EMS.Shared.Theme.Controls
{
    partial class Grid
    {
        void InitializeComponent()
        {
            AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0,0,0,0);
            AbsoluteBindTop = true;
            FixedSize = true;
            AllowMultiSelect = true;
            AllowUserToResizeColumns = true;
            DoubleColumnSeparatorInFlatStyle = true;
            RightToLeftLayout = false;
            PaintActiveRowBackColorOverGridLines = true;
        }
    }
}
