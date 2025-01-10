using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Report Font 2 #114</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Report Font 2")]
    public class ReportFont2 : LoadableFontScheme 
    {
        public ReportFont2()
        {
            try
            {
                this.Font = new System.Drawing.Font("Arial", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
