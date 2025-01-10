using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>Status bar #53</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Status bar")]
    public class StatusBar : ColorScheme 
    {
        public StatusBar()
        {
            this.ForeColor = Color.FromArgb(255,0,0);
            this.BackColor = SystemColors.ButtonFace;
        }
    }
}
