using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>Component Builder Warning #48</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Component Builder Warning")]
    public class ComponentBuilderWarning : ColorScheme 
    {
        public ComponentBuilderWarning()
        {
            this.ForeColor = Color.FromArgb(255,0,0);
            this.BackColor = SystemColors.ButtonFace;
        }
    }
}
