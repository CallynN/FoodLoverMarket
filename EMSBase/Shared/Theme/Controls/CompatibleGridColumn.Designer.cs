namespace EMS.Shared.Theme.Controls
{
    partial class CompatibleGridColumn
    {
        void InitializeComponent()
        {
            AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0,0,0,0);
            AbsoluteBindTop = true;
            FontScheme = new EMS.Shared.Theme.Fonts.DefaultTableTitle();
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultWindow();
            Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            AllowSort = false;
            RightToLeftLayout = false;
        }
    }
}
