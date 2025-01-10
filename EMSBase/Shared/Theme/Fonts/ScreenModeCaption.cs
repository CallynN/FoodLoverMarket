using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Screen Mode Caption #111</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Screen Mode Caption")]
    public class ScreenModeCaption : LoadableFontScheme 
    {
        public ScreenModeCaption()
        {
            try
            {
                this.Font = new System.Drawing.Font("MS Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
