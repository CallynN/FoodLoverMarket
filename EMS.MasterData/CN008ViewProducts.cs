using ENV;
using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Firefly.Box.Flow;
using System.Diagnostics;

namespace EMS.MasterData
{
    public class CN008ViewProducts : UIControllerBase
    {
        #region Models 
        //        public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();
        public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();
        #endregion
        #region Columns 
        public readonly TextColumn P_Status = new TextColumn("P_Status", "U");
        #endregion

        public CN008ViewProducts()
        {
            Title = "CN008 View Products";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {

            From = Product_;
            Debug.WriteLine(P_Status);


            Where.Add(Product_.Status.IsEqualTo(P_Status));



            #region Column Selection and UserFlow
            Columns.Add(Product_.Id);
            Columns.Add(Product_.Name);
            Columns.Add(Product_.WeightedItem);
            Columns.Add(Product_.SuggestedSellingPrice);
            Columns.Add(Product_.Status);

            #endregion
        }

        public void Run(TextParameter pP_Status)
        {
            #region BindParameters
            BindParameter(P_Status, pP_Status);
            #endregion
            Execute();
        }

        protected override void OnLoad()
        {
            Activity = Activities.Browse;
            View = () => new Views.CN008ViewProductsView(this);
        }
    }
}