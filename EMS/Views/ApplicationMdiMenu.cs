using ENV.UI.Menus;
using Firefly.Box;



namespace EMS.Views
{
    public class ApplicationMdiMenu : MenuStripBase
    {
        public ApplicationMdiMenu()
        {
            Add(

                new MenuEntry("&File")
                #region items
                {
                    new RaiseCommand("&Shell to OS", ENV.Commands.ShellToOS){ ShortcutKeys = (System.Windows.Forms.Keys.Control|System.Windows.Forms.Keys.Z) }
                    , new Seperator()
                    , new ManagedCommand("E&xit System", Command.ExitApplication)
                }
                #endregion
                , new MenuEntry("&Edit")
                #region items
                {
                    new ManagedCommand("&Cancel", Command.UndoChangesInRow)
                    , new ManagedCommand("Undo Editing", Command.UndoEditing)
                    , new Seperator()
                    , new ManagedCommand("Edit Mode", Command.SelectToFirstCharacter)
                    , new ManagedCommand("&Zoom", Command.Expand)
                    , new ManagedCommand("&Wide", Command.ExpandTextBox)
                    , new Seperator()
                    , new ManagedCommand("&Delete Line", Command.DeleteRow)
                    , new ManagedCommand("Crea&te Line", Command.InsertRow)
                    , new ManagedCommand("Di&tto", Command.SetFocusedControlValueSameAsInPreviousRow)
                    , new ManagedCommand("Set to &NULL", Command.SetFocusedControlValueToNull)
                }
                #endregion
                , new MenuEntry("&Options")
                #region items
                {
                    new ManagedCommand("&Modify Records", Command.SwitchToUpdateActivity)
                    , new ManagedCommand("&Create Records", Command.SwitchToInsertActivity)
                    , new ManagedCommand("&Query Records", Command.SwitchToBrowseActivity)
                    , new Seperator()
                    , new ManagedCommand("&Locate a Record", ENV.Commands.FindRows)
                    , new ManagedCommand("Locate &Next", ENV.Commands.FindNextRow)
                    , new ManagedCommand("&Range of Records", ENV.Commands.FilterRows)
                    , new ManagedCommand("&View by Key", ENV.Commands.SelectOrderBy)
                    , new ManagedCommand("&Sort Records", ENV.Commands.CustomOrderBy)
                    , new DeveloperToolsMenu(Application.Instance, typeof (Shared.DataSources), Roles.UserManager)
                    , new ManagedCommand("Clear Value", ENV.Commands.ClearCurrentValueInTemplate)
                    , new ManagedCommand("Clear Template", ENV.Commands.ClearTemplate)
                    , new ManagedCommand("From Values", ENV.Commands.TemplateFromValues)
                    , new ManagedCommand("To Value", ENV.Commands.TemplateToValues)
                    , new ManagedCommand("Define Expression", ENV.Commands.TemplateExpression)
                }
                #endregion
                , new MenuEntry("&Help")
                #region items
                {
                    new ManagedCommand("&Help", Command.Help)
                    , new Seperator()
                    , new RaiseCommand("&About", ENV.Commands.About)
                }
                #endregion
                , new MenuEntry("EMS") { Enabled = false }
                , new Seperator()
                , new MenuEntry("&A Branchs")
                #region items
                {
                     new MenuEntry("&A Create Branch", () => Create<MasterData.ICN001CreateBranch>().Run()) {  CloseActiveControllers = true }
                     , new MenuEntry("&B Edit Branch", () => Create<MasterData.ICN002EditBranch>().Run()) {  CloseActiveControllers = true }
                     , new MenuEntry("&C View Branch", () => Create<MasterData.ICN003ViewBranchSearch>().Run()) {  CloseActiveControllers = true }

                }
                #endregion
                , new MenuEntry("&B Products")
                #region items
                {
                     new MenuEntry("&A Create Product", () => Create<MasterData.ICN005CreateProduct>().Run()) {  CloseActiveControllers = true }
                     , new MenuEntry("&B Edit Product", () => Create<MasterData.ICN006EditProduct>().Run()) {  CloseActiveControllers = true }
                     , new MenuEntry("&C View Product", () => Create<MasterData.CN007ViewProductsSearch>().Run()) {  CloseActiveControllers = true }

                }
                #endregion
                , new MenuEntry("&C Products")
                #region items
                {
                     new MenuEntry("&A Create & Edit Branch Product", () => Create<MasterData.CN013CreateBranchProduct>().Run()) {  CloseActiveControllers = true }
                     //, new MenuEntry("&B Edit Product", () => Create<MasterData.ICN006EditProduct>().Run()) {  CloseActiveControllers = true }
                     //, new MenuEntry("&C View Product", () => Create<MasterData.CN007ViewProductsSearch>().Run()) {  CloseActiveControllers = true }

                }
                #endregion
                , new MenuEntry("&D Imports and Exports")
                #region items
                {
                     new MenuEntry("&A Import Program", () => Create<MasterData.CN009ImportPragram>().Run()) {  CloseActiveControllers = true }
                     ,new MenuEntry("&A Export Program", () => Create<MasterData.CN011ExportProgram>().Run()) {  CloseActiveControllers = true }

                }
                #endregion
                

               
            );
        }
    }
}