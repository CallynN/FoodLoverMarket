﻿using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Dialog Text #26</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Dialog Text")]
    class DialogText : LoadableFontScheme 
    {
        public DialogText()
        {
            try
            {
                this.Font = new System.Drawing.Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch(System.Exception e)
            {
                ENV.ErrorLog.WriteToLogFile(e);
            }
        }
    }
}
