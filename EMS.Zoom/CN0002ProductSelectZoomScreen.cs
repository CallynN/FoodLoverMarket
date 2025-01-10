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
    public class CN0002ProductSelectZoomScreen : FlowUIControllerBase
    {
        #region Models 
        public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();
        #endregion
        #region Column Selection and UserFlow 

        public readonly NumberColumn P_Product = new NumberColumn("P_Product", "12.2");

        #endregion

        public CN0002ProductSelectZoomScreen()
        {
            Title = "CN0002 Product Select Zoom Screen";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {
            From = Product_;
            StartOnRowWhere.Add(Product_.Id.IsGreaterOrEqualTo(P_Product));
            Where.Add(Product_.Status.IsEqualTo("A")) ;
            OrderBy = Product_.SortByPKProduct;

            #region Column Selection and User Flow
            Columns.Add(P_Product);

            Columns.Add(Product_.Id);
            Columns.Add(Product_.Name);
            Columns.Add(Product_.WeightedItem);
            Columns.Add(Product_.SuggestedSellingPrice);
            #endregion


        }

        public void Run(NumberParameter pP_ProductID)
        {
            #region BindParameters
            BindParameter(P_Product, pP_ProductID);
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
            View = () => new Views.CN0002ProductSelectZoomScreenView(this);
        }

        protected override void OnSavingRow()
        {
            P_Product.Value = Product_.Id;
            //P_SupplierNo.Value = Supplier.Supplier_;
        }


    }
}