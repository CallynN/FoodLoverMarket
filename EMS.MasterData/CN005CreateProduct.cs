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
    public class CN005CreateProduct : FlowUIControllerBase, ICN005CreateProduct
    {
        #region Models

        #endregion
        #region Column
        public readonly NumberColumn V_ProductId = new NumberColumn("V_ProductId", "10");
        public readonly TextColumn V_ProductName = new TextColumn("Name", "100");
        public readonly BoolColumn V_ProductWeightedItem = new BoolColumn("WeightedItem");
        public readonly NumberColumn V_ProductSuggestedSellingPrice = new NumberColumn("SuggestedSellingPrice", "12.2");
        public readonly TextColumn V_Accept = new TextColumn("V_Accept", "U") { InputRange = "Y,N" };
        #endregion

        public CN005CreateProduct()
        {
            Title = "CN005 Create Product";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {
            #region Column Selection and userFlow 

            Columns.Add(V_ProductName);
            Columns.Add(V_ProductWeightedItem);
            Columns.Add(V_ProductSuggestedSellingPrice);



            Columns.Add(V_Accept).BindValue(() => "N");
            #endregion

        }

        protected override void OnStart()
        {
            V_ProductId.Value = 0;

        }


        public void Run()
        {
            Execute();
        }

        protected override void OnLoad()
        {
            Exit(ExitTiming.AfterRow);
            BindGoToToNextRowAfterLastControl(() => !(V_Accept == "N"));
            View = () => new Views.CN005CreateProductView(this);
        }


        protected override void OnLeaveRow()
        {

            //validate ID is zero and to save
            if (V_ProductId == 0 && V_Accept == 'Y')
            {
                
                //Create Next Number for ID value 
                Cached<GetLastID>().Run(V_ProductId);
                //Debug.WriteLine(V_ProductId.Value);

                //Update Class 
                Cached<UpdateProduct>().Run();
                
            }


        }




        // Update Product Table 
        internal class UpdateProduct : BusinessProcessBase
        {
            CN005CreateProduct _parent;

            #region Models 
            public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();

            #endregion



            public UpdateProduct(CN005CreateProduct parent)
            {
                _parent = parent;
                InitializeDataViewAndUserFlow();

            }
            void InitializeDataViewAndUserFlow()
            {

                Relations.Add(Product_, RelationType.InsertIfNotFound, Product_.Id.IsEqualTo(_parent.V_ProductId), Product_.SortByPKProduct);

                Columns.Add(Product_.Id);
                Columns.Add(Product_.Name);
                Columns.Add(Product_.WeightedItem);
                Columns.Add(Product_.SuggestedSellingPrice);
                Columns.Add(Product_.Status);


            }

            public void Run()
            {
                Execute();
            }
            protected override void OnLoad()
            {
                Exit(ExitTiming.AfterRow);
            }


            protected override void OnEnterRow()
            {

            }

            //Save data to Table 
            protected override void OnLeaveRow()
            {

                Product_.Id.Value = _parent.V_ProductId;
                Product_.Name.Value = _parent.V_ProductName.Value;
                Product_.WeightedItem.Value = _parent.V_ProductWeightedItem.Value;
                Product_.SuggestedSellingPrice.Value = _parent.V_ProductSuggestedSellingPrice;
                Product_.Status.Value = 'A';


            }


        }


        //Begin GetLastID Class
        internal class GetLastID : BusinessProcessBase
        {
            CN005CreateProduct _parent;
            #region Models
            
            #endregion
            #region Columns
            public readonly NumberColumn V_MaxID = new NumberColumn("V_MaxID");
            public readonly NumberColumn V_temp = new NumberColumn("V_temp");
            #endregion

            //DynamicSQLEntity dynamicSql;
            public GetLastID(CN005CreateProduct parent)
            {
                var dynamicSql = new DynamicSQLEntity(Shared.DataSources.Oracle7, @"select Max(ID) from Product ");


                //dynamicSql.AddParameter(() => V_PromotionNo);//:1
                dynamicSql.Columns.Add(V_MaxID);
                From = dynamicSql;

                // InitializeDataViewAndUserFlow();
                MarkParameterColumns(V_MaxID);

            }

            public void Run(NumberParameter pP_GetNextMaxGroupNo)
            {
                #region BindParameter
                BindParameter(V_temp, pP_GetNextMaxGroupNo);
                #endregion

                Execute();
            }

            protected override void OnLoad()
            {


            }


            protected override void OnLeaveRow()
            {
                V_temp.Value = V_MaxID.Value + 1;
            }



        }

    }
}