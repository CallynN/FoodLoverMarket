using ENV;
using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Firefly.Box.Flow;

namespace EMS.MasterData
{
    public class CN014CreateBranchProductScreen : FlowUIControllerBase
    {
        #region Models 
        public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();
        public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();
        public readonly EMS.Models.MasterData.Product NProduct_ = new EMS.Models.MasterData.Product();
        public readonly EMS.Models.MasterData.BranchProduct BranchProduct_ = new EMS.Models.MasterData.BranchProduct();

        #endregion
        #region Column 
        public readonly NumberColumn P_Branch = new NumberColumn("P_Branch");

        #endregion

        public CN014CreateBranchProductScreen()
        {
            Title = "CN014 Create Branch Product Screen";
            InitializeDataViewAndUserFlow();
        }


        void InitializeDataViewAndUserFlow()
        {
            From = BranchProduct_;
            Where.Add(BranchProduct_.BranchID.IsEqualTo(P_Branch));
            #region Relations 
            Relations.Add(Branch_, RelationType.Find, Branch_.Id.IsEqualTo(P_Branch),Branch_.SortByPkBranch);
            Relations.Add(Product_, RelationType.Find, Product_.Id.IsEqualTo(BranchProduct_.ProductID), Product_.SortByPKProduct);
            Relations.Add(NProduct_, RelationType.Find, NProduct_.Id.IsEqualTo(Product_.Id), Product_.SortByPKProduct);

            #endregion

            #region Column Selection and UserFlow 
            Columns.Add(BranchProduct_.BranchID);
            Columns.Add(Branch_.Id);
            Columns.Add(Branch_.Name);


            
            Columns.Add(Product_.Id);
            //Columns.Add(Product_.Name);
            Flow.Add<Zoom.CN0002ProductSelectZoomScreen>(c => c.Run(Product_.Id), FlowMode.ExpandAfter);
            BranchProduct_.ProductID.BindValue(NProduct_.Id);

            

            #endregion


        }

        public void Run(NumberParameter pP_Branch)
        {
            #region BindParameter
            BindParameter(P_Branch, pP_Branch);
            #endregion

            Execute();
        }

        protected override void OnSavingRow()
        {
            BranchProduct_.BranchID.Value = P_Branch.Value;
            BranchProduct_.ProductID.Value = NProduct_.Id;
            
            
        }


        protected override void OnLoad()
        {
            
            View = () => new Views.CN014CreateBranchProductScreenView(this);
        }



    }
}