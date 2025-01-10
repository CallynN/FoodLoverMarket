namespace EMS.Shared.Theme.Controls
{
    partial class Button
    {
        void InitializeComponent()
        {
            AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0,0,0,0);
            AbsoluteBindTop = true;
            FontScheme = new EMS.Shared.Theme.Fonts.PushButtonDefaultFont();
            RightToLeftLayout = false;
            HyperLinkColorScheme = new EMS.Shared.Theme.Colors.HyperlinkPushbuttonText();
            HyperLinkPressedColorScheme = new EMS.Shared.Theme.Colors.HyperlinkPushbuttonVisited();
            HyperLinkMouseEnterColorScheme = new EMS.Shared.Theme.Colors.HyperlinkPushB_Walkthrough();
            FixedBackColorOnNormalStyle = true;
        }
    }
}
