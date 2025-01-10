using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Small Font #31</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Small Font")]
    public class SmallFont : LoadableFontScheme 
    {
        public SmallFont()
        {
            try
            {
                this.Font = new System.Drawing.Font("Small Fonts", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
