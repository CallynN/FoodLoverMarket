using Firefly.Box;
using ENV.Data;
using ENV;
using Firefly.Box.Flow;
using System.Windows.Forms;
using Message = ENV.Message;
using Firefly.Box.Advanced;
using System.Diagnostics;

namespace EMS.MasterData
{
    public class CN013CreateBranchProduct : FlowUIControllerBase
    {
        #region Models 
        //public readonly EMS.Models.MasterData.BranchProduct BranchProduct_  = new EMS.Models.MasterData.BranchProduct();

        public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

        #endregion
        #region Columns
        public readonly NumberColumn V_Branch = new NumberColumn("V_Branch", "10");
        internal readonly TextColumn V_CreateOrAmend = new TextColumn("V_Create_or_Amend", "U") { InputRange = "Create,Amend" };
        readonly BoolColumn Is_New = new BoolColumn("IS-New");
        internal readonly TextColumn V_Continue = new TextColumn("V_Continue", "U") { InputRange = "Y,N" };
        #endregion


        public CN013CreateBranchProduct()
        {
            Title = "CN013 Create Branch Product";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {
           // From = BranchProduct_;

            #region Relations 
            Relations.Add(Branch_, Branch_.Id.IsEqualTo(V_Branch) , Branch_.SortByPkBranch);
            #endregion
            #region Column Selection and User Flow
            Columns.Add(V_CreateOrAmend);

            Columns.Add(V_Branch);

            Flow.Add<Zoom.CN0001BranchSelectZoomScreen>(c => c.Run(V_Branch), FlowMode.ExpandAfter);

            Flow.Add(() => Message.ShowError("A Branch must be input "), () => V_Branch == 0 && Branch_.Id == 0 );

            Columns.Add(Branch_.Id);
            Columns.Add(Branch_.Name);
            //Columns.Add(Supplier.SupplierName);

            //Flow.Add(() => Message.ShowError("Supplier does not exist"), () => Supplier.Supplier_ == 0);

            Columns.Add(Is_New);

            Columns.Add(V_Continue);


            Flow.Add<CN014CreateBranchProductScreen>(c =>
            {
                LockCurrentRow();
                c.Run(V_Branch);
            }, FlowMode.Tab);

            #endregion

        }

        public void Run()
        {
            Execute();
        }

        protected override void OnLoad()
        {
            RowLocking = LockingStrategy.OnUserEdit;
            TransactionScope = TransactionScopes.RowLocking;
            OnDatabaseErrorRetry = false;
            GoToToNextRowAfterLastControl = true;

            View = () => new Views.CN013CreateBranchProductView(this);
        }



    }
}