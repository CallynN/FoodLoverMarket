using System.Drawing;
namespace EMS.Views.Help
{
    /// <summary>--------Release Notes---------</summary>
    public class _ReleaseNotes : ENV.UI.CustomHelp 
    {
        public _ReleaseNotes()
        {
            Caption = "--------Release Notes---------";
            ColorScheme = new Shared.Theme.Colors.DefaultPrintFormColor();
            FontScheme = new Shared.Theme.Fonts.DefaultHelp();
            Location = new Point(180, 26);
            Size = new Size(215, 273);
            SystemMenu = false;
            Text = "";
        }
    }
}
