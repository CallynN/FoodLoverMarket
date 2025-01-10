using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Strike Through #112</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Strike Through")]
    class StrikeThrough : LoadableFontScheme 
    {
        public StrikeThrough()
        {
            try
            {
                this.Font = new System.Drawing.Font("MS Sans Serif", 8F, FontStyle.Strikeout, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
