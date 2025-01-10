using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Report Font #113</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Report Font")]
    class ReportFont : LoadableFontScheme 
    {
        public ReportFont()
        {
            try
            {
                this.Font = new System.Drawing.Font("MS Sans Serif", 5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
