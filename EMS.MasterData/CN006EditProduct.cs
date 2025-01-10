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
    public class CN006EditProduct : UIControllerBase, ICN006EditProduct
    {
        #region Models 
        public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();

        #endregion
        #region Column

        #endregion
        public CN006EditProduct()
        {
            Title = "CN006 Edit Products";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {
            From = Product_;

            #region Column Selection and UserFlow 

            Columns.Add(Product_.Id);
            Columns.Add(Product_.Name);
            Columns.Add(Product_.WeightedItem);
            Columns.Add(Product_.SuggestedSellingPrice);
            Columns.Add(Product_.Status);

            #endregion
        }

        public void Run()
        {
            Execute();
        }

        protected override void OnLoad()
        {
            AllowInsert = false;
            View = () => new Views.CN006EditProductView(this);
        }
    }
}