using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>GreenLight #105</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("GreenLight")]
    public class GreenLight : ColorScheme 
    {
        public GreenLight()
        {
            this.ForeColor = SystemColors.WindowText;
            this.BackColor = Color.FromArgb(0,255,0);
        }
    }
}
