﻿using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Reserved #20</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Reserved")]
    public class Reserved_8 : LoadableFontScheme 
    {
        public Reserved_8()
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
