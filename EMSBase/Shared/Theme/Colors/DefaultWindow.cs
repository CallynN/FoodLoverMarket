using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>Default Window #1</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Default Window")]
    public class DefaultWindow : ColorScheme 
    {
        public DefaultWindow()
        {
            this.ForeColor = SystemColors.WindowText;
            this.BackColor = SystemColors.Window;
        }
    }
}
