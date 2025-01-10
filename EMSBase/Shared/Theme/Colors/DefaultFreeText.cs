using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>Default Free Text #3</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Default Free Text")]
    public class DefaultFreeText : ColorScheme 
    {
        public DefaultFreeText()
        {
            this.ForeColor = SystemColors.HighlightText;
            this.BackColor = SystemColors.Highlight;
        }
    }
}
