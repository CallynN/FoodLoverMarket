namespace EMS.Shared.Theme.Controls
{
    public partial class Button : ENV.UI.Button 
    {
        /// <summary>Button</summary>
        public Button()
        {
            if (!DesignMode)
            	FixedBackColorInNonFlatStyles = ENV.UserSettings.FixedBackColorInNonFlatStyles;
            InitializeComponent();
        }
        protected override Firefly.Box.UI.ColorScheme GetColorByIndex(int index)
        {
            return global::EMS.Shared.Theme.ColorSchemes.Find(index);
        }
    }
}
