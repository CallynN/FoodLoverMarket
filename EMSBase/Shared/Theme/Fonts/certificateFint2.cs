using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>certificate fint 2 #116</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("certificate fint 2")]
    class certificateFint2 : LoadableFontScheme 
    {
        public certificateFint2()
        {
            try
            {
                this.Font = new System.Drawing.Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
