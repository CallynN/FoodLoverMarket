namespace EMS.Shared.Theme.Controls
{
    public partial class CheckBox : ENV.UI.CheckBox 
    {
        /// <summary>CheckBox</summary>
        public CheckBox()
        {
            if (!DesignMode)
            	FixedBackColorInNonFlatStyles = ENV.UserSettings.FixedBackColorInNonFlatStyles;
            InitializeComponent();
        }
    }
}
