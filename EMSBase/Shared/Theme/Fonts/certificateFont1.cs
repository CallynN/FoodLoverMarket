using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>certificate font 1 #115</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("certificate font 1")]
    class certificateFont1 : LoadableFontScheme 
    {
        public certificateFont1()
        {
            try
            {
                this.Font = new System.Drawing.Font("Arial Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
