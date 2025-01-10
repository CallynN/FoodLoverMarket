using ENV.UI.Menus;
using Firefly.Box;
namespace EMS.Views
{
    public class DefaultContextMenu : ContextMenuStripBase
    {
        public DefaultContextMenu(System.ComponentModel.IContainer container) : base(container)
        {
            Add(
                 new MenuEntry("EMS") { Enabled = false }
                , new Seperator()
                
               
                , new MenuEntry("&L Information Technology", Role: Roles.TableFullAccess)
                #region items
                {
                    // new MenuEntry("&A Entities(Tables)", () => Create<ItemMasterdata.I_03149EntitiesTables>().Run()){ Role = Roles.TableFullAccess, CloseActiveControllers = true }
                  
                  
                }
                #endregion
            );
        }
    }
}
