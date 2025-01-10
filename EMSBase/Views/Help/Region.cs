using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>Region</summary>
    public class Region : ENV.UI.CustomHelp 
    {
        public Region()
        {
            Caption = "Region";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            Text = 
@"Region Code: Two digit code to identify
the region in S.A.

Description: Identify region eg. Natal,
North West.
";
        }
    }
}
