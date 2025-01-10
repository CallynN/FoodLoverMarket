using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Toolkit Windows Font #30</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Toolkit Windows Font")]
    public class ToolkitWindowsFont : LoadableFontScheme 
    {
        public ToolkitWindowsFont()
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
