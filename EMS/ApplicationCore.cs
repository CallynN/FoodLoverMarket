using Firefly.Box;
using ENV.Data;
using ENV;
using Firefly.Box.Advanced;
namespace EMS
{
    /// <summary>Main Program(P#1)</summary>
    /// <remark>Last change before Migration: 04/01/7908 14:49:47</remark>
    public class ApplicationCore : Application 
    {
        Views.ApplicationMdi _mdi;
        public ApplicationCore()
        {
            _applicationRoles = new ENV.Security.RolesCollection(typeof(Roles));
            Title = "Main Program";
            InitializeHandlers();
            _applicationPrograms = _staticPrograms;
            _applicationEntities = _staticEntities;
        }
        void InitializeHandlers()
        {
            Handlers.Add(Commands.CustomCommand_20, HandlerScope.UnhandledCustomCommandInModule).Invokes += e => 
            #region
            {
                e.Handled = true;
                u.KBPut(Command.UndoChangesInRow);
                u.KBPut(Command.Exit);
            };
            #endregion
        }
        #region Run Methods
        public static void Run()
        {
            Instance._mdi = new Views.ApplicationMdi();
            ENV.UI.Grid.AlwaysEnableGridEnhancements = true;
            ENV.UI.Grid.AlwaysUseUnderConstructionNewGridLook = true;
            Instance.Run(Instance._mdi, () => Instance);
            Context.Current[typeof(Application)] = null;
            
        }
        protected override void Execute()
        {
            ENV.Security.UserManager.Load();
            ENV.Security.UserManager.Administrator = Roles.Administrator;
            if (!ENV.Security.UserManager.ShowLoginDialog(false))
                return;
            #if DEBUG
            Common.EnableDeveloperTools = true;
            #endif
            ;
            Common.BindStatusBar(_mdi.mainStatusLabel, _mdi.userStatusLabel, _mdi.activityStatusLabel, _mdi.expandStatusLabel, _mdi.expandTextBoxStatusLabel, _mdi.insertOverrideStatusLabel, _mdi.versionStatusLabel);
            base.Execute();
        }
        #endregion
        #region Init Programs and Entities Collection
        protected override ProgramCollection LoadAllProgramsCollection()
        {
            if (_staticPrograms==null)
                _staticPrograms = new ApplicationPrograms();
            return _staticPrograms;
        }
        protected override ApplicationEntityCollection LoadAllEntitiesCollection()
        {
            if (_staticEntities==null)
                _staticEntities = new ApplicationEntities();
            return _staticEntities;
        }
        #endregion
        #region Instance Management
        public static ApplicationCore Instance 
        {
            get
            {
                var result = Context.Current[typeof(Application)] as ApplicationCore;
                if (result == null)
                {
                    result = new ApplicationCore();
                    Context.Current[typeof(Application)] = result;
                }
                return result;
            }
        }
        static ApplicationPrograms _staticPrograms;
        static ApplicationEntities _staticEntities;
        #endregion
    }
}
