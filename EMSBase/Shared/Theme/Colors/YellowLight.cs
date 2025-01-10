using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>YellowLight #106</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("YellowLight")]
    public class YellowLight : ColorScheme 
    {
        public YellowLight()
        {
            this.ForeColor = SystemColors.WindowText;
            this.BackColor = Color.FromArgb(255,255,0);
        }
    }
}
