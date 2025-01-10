using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>Exit OS Operation #71</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Exit OS Operation")]
    class ExitOSOperation : ColorScheme 
    {
        public ExitOSOperation()
        {
            this.ForeColor = Color.FromArgb(64,0,64);
            this.BackColor = SystemColors.Window;
        }
    }
}
