namespace EMS.Shared.Theme.Controls
{
    partial class Form
    {
        void InitializeComponent()
        {
            DisableMDIChildZOrdering = ENV.UserSettings.DisableMDIChildZOrdering;
            AutoZOrder = true;
            StartPosition = Firefly.Box.UI.WindowStartPosition.Custom;
            ClientSize = new System.Drawing.Size(400,325);
            PaintChildControls = true;
            AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0,0,0,0);
        }
    }
}
