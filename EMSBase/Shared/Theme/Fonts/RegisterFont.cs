using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Register Font #118</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Register Font")]
    public class RegisterFont : LoadableFontScheme 
    {
        public RegisterFont()
        {
            try
            {
                this.Font = new System.Drawing.Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
