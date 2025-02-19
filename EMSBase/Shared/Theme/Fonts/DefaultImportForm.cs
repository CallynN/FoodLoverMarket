﻿using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Default Import Form #8</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Default Import Form")]
    public class DefaultImportForm : LoadableFontScheme 
    {
        public DefaultImportForm()
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
