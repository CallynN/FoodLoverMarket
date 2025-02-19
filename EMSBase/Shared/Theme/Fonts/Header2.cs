﻿using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Header 2 #52</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Header 2")]
    public class Header2 : LoadableFontScheme 
    {
        public Header2()
        {
            try
            {
                this.Font = new System.Drawing.Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
