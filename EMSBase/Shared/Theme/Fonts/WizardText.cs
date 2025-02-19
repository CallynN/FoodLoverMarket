﻿using System.Drawing;
using ENV.UI;
namespace EMS.Shared.Theme.Fonts
{
    /// <summary>Wizard text #83</summary>
    [System.ComponentModel.DesignerCategory("Component")]
    [System.ComponentModel.Description("Wizard text")]
    class WizardText : LoadableFontScheme 
    {
        public WizardText()
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
