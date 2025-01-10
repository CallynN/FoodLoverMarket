namespace EMS.Shared.Theme.Controls
{
    public partial class CompatibleGrid : Grid 
    {
        /// <summary>CompatibleGrid</summary>
        public CompatibleGrid()
        {
            GridColumnType = typeof(CompatibleGridColumn);
            DefaultTextBoxType = typeof(CompatibleTextBox);
            InitializeComponent();
        }
    }
}
