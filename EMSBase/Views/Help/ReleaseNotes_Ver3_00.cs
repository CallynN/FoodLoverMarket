using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Release Notes (Ver 3.00)</summary>
    public class ReleaseNotes_Ver3_00 : ENV.UI.CustomHelp 
    {
        public ReleaseNotes_Ver3_00()
        {
            Caption = "Release Notes (Ver 3.00)";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = 
@"BOXER CASH & CARRY :MERCHANDISING SYSTEM
                                        
(version 3.00) : 25/03/97

1. What's new in this version/release?

1.1 Sell Price Management

1.2 Housekeeping
1.2.1 Move To History
1.2.2 File Cleanup
";
        }
    }
}
