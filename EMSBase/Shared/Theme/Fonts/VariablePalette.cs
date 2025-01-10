using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Variable Palette #37</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Variable Palette")]
    class VariablePalette : LoadableFontScheme 
    {
        public VariablePalette()
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
