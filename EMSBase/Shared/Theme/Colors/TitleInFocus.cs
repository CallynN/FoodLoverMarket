using System.Drawing;
using Firefly.Box.UI;
namespace EMS.Shared.Theme.Colors
{
    /// <summary>Title in Focus #32</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Title in Focus")]
    public class TitleInFocus : ColorScheme 
    {
        public TitleInFocus()
        {
            this.ForeColor = SystemColors.ActiveCaptionText;
            this.BackColor = SystemColors.ActiveCaption;
        }
    }
}
