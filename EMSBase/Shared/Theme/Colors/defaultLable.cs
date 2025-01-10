using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>default lable #102</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("default lable")]
    class defaultLable : ColorScheme 
    {
        public defaultLable()
        {
            this.ForeColor = SystemColors.WindowText;
            this.BackColor = Color.FromArgb(122,122,122);
            this.TransparentBackground = true;
        }
    }
}
