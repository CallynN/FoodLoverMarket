using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>RedLight #108</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("RedLight")]
    public class RedLight : ColorScheme 
    {
        public RedLight()
        {
            this.ForeColor = SystemColors.WindowText;
            this.BackColor = Color.FromArgb(255,0,0);
        }
    }
}
