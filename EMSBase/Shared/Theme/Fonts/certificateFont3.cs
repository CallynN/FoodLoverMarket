using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>certificate font 3 #117</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("certificate font 3")]
    public class certificateFont3 : LoadableFontScheme 
    {
        public certificateFont3()
        {
            try
            {
                this.Font = new System.Drawing.Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
