using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Broken Property #35</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Broken Property")]
    public class BrokenProperty : LoadableFontScheme 
    {
        public BrokenProperty()
        {
            try
            {
                this.Font = new System.Drawing.Font("MS Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
