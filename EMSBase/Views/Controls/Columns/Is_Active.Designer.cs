using System.Drawing;
using Firefly.Box.UI;
using Firefly.Box;
namespace EMS.Views.Controls.Columns
{
    partial class Is_Active
    {
        Shared.Theme.Fonts.DefaultTableEditField fntDefaultTableEditField;
        void InitializeComponent()
        {
            this.fntDefaultTableEditField = new EMS.Shared.Theme.Fonts.DefaultTableEditField();
            this.Border = Firefly.Box.UI.ControlBorderStyle.None;
            this.FontScheme = this.fntDefaultTableEditField;
            this.IgnoreEmptyBoundValues = true;
            this.Style = Firefly.Box.UI.ControlStyle.Standard;
            this.Values = "True,False";
        }
    }
}
