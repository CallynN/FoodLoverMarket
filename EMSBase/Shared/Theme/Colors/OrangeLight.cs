using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>OrangeLight #107</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("OrangeLight")]
    class OrangeLight : ColorScheme 
    {
        public OrangeLight()
        {
            this.ForeColor = SystemColors.WindowText;
            this.BackColor = Color.FromArgb(255,128,0);
        }
    }
}
