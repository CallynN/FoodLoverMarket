namespace EMS.Shared.Theme.Controls
{
    partial class TabControl
    {
        void InitializeComponent()
        {
            AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0,0,0,0);
            AbsoluteBindTop = true;
            Alignment = System.Drawing.ContentAlignment.TopLeft;
            RightToLeftLayout = false;
            FontScheme = new EMS.Shared.Theme.Fonts.DefaultTableEditField();
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultEditField();
            AllowChangeInBrowse = false;
            UseVisualStyles = false;
            AlwaysShowFocusRectangle = true;
        }
    }
}
