using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>Menu bar #51</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Menu bar")]
    public class MenuBar : ColorScheme 
    {
        public MenuBar()
        {
            this.ForeColor = Color.FromArgb(255,0,0);
            this.BackColor = SystemColors.ButtonFace;
        }
    }
}
