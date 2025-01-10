using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>Screen Mode Caption #101</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Screen Mode Caption")]
    public class ScreenModeCaption : ColorScheme 
    {
        public ScreenModeCaption()
        {
            this.ForeColor = Color.FromArgb(0,0,160);
            this.BackColor = Color.FromArgb(0,0,0);
            this.TransparentBackground = true;
        }
    }
}
