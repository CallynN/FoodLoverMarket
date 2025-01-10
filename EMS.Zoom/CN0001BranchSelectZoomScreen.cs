using ENV;
using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Firefly.Box.Flow;

namespace EMS.Zoom
{
    public class CN0001BranchSelectZoomScreen : FlowUIControllerBase
    {
        #region Models 
        public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();
        #endregion
        #region Column Selection and UserFlow 

        public readonly NumberColumn P_Branch = new NumberColumn("P_Branch","12.2");

        #endregion


        public CN0001BranchSelectZoomScreen()
        {
            Title = "CN0001 Branch Select Zoom Screen";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {
            From = Branch_;
            StartOnRowWhere.Add(Branch_.Id.IsGreaterOrEqualTo(P_Branch));
            Where.Add(Branch_.Status.IsEqualTo("A"));
            OrderBy = Branch_.SortByPkBranch;

            #region Column Selection and User Flow
            Columns.Add(P_Branch);

            Columns.Add(Branch_.Id);
            Columns.Add(Branch_.Name);
            Columns.Add(Branch_.TelephoneNumber);
            Columns.Add(Branch_.OpenDate);
            #endregion

        }
    

        public void Run(NumberParameter pP_Branch)
        {
            #region BindParameters
            BindParameter(P_Branch, pP_Branch);
            #endregion
            Execute();
        }

        protected override void OnLoad()
        {
            OnDatabaseErrorRetry = false;
            Activity = Activities.Browse;
            AllowDelete = false;
            AllowInsert = false;
            AllowUpdate = false;
            AllowSelect = true;
            View = () => new Views.CN0001BranchSelectZoomScreenView(this);
        }


        protected override void OnSavingRow()
        {
            P_Branch.Value = Branch_.Id;
            //P_SupplierNo.Value = Supplier.Supplier_;
        }

    }
}