using Firefly.Box.UI;
namespace EMS.Views
{
    public class ContextMenuMap : ENV.UI.ContextMenuMap 
    {
        public ContextMenuMap(System.ComponentModel.IContainer container)
        {
            this.Add(-2, () => new DefaultPulldownMenu(container));
            this.Add(-1, () => new DefaultContextMenu(container));
        }
    }
}
