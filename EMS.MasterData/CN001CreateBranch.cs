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
    public class CN001CreateBranch : FlowUIControllerBase, ICN001CreateBranch
    {

        #region Models 

        public readonly EMS.Models.MasterData.Branch NextNumber = new EMS.Models.MasterData.Branch();

        #endregion
        #region Columns 

        public readonly NumberColumn V_BranchId = new NumberColumn("V_BranchId");
        public readonly DateColumn V_OpenDate = new DateColumn("V_OpenDate", "DD/MM/YYYY");
        public readonly TextColumn V_BranchName = new TextColumn("V_BranchName","100");
        public readonly TextColumn V_Telephone = new TextColumn("V_Telephone","###############");
        public readonly TextColumn V_Accept = new TextColumn("V_Accept", "U") { InputRange = "Y,N" };
        #endregion

        public CN001CreateBranch()
        {
            Title = "CN001 Create Branch";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {

            #region Column Selection and userFlow 

            Columns.Add(V_BranchName);
            Columns.Add(V_Telephone);
            Columns.Add(V_OpenDate);


            Columns.Add(V_Accept).BindValue(() => "N");
            #endregion

        }

        public void Run()
        {
            Execute();
        }

        protected override void OnStart()
        {
            V_BranchId.Value = 0;

        }


        protected override void OnLoad()
        {
            Exit(ExitTiming.AfterRow);
            BindGoToToNextRowAfterLastControl(() => !(V_Accept == "N"));
            View = () => new Views.CN001CreateBranchView(this);
        }


        protected override void OnLeaveRow()
        {

            //validate ID is zero and to save
            if (V_BranchId == 0 && V_Accept == 'Y')
            {
                //validate  that date choosen is not less than current date or equal today 
                if (V_OpenDate.Value <= Date.Now)
                {
                    Message.ShowError("Date Can Not be Less or Equal to To "+ (Date.Now).ToString() );
                }
                else
                {
                    //Create Next Number for ID value 
                    Cached<GetLastID>().Run(V_BranchId);
                    //Debug.WriteLine(V_BranchId.Value);

                    //Update Class 
                    Cached<UpdateBranch>().Run();
                }
            }


        }



        // Update Branch Table 
        internal class UpdateBranch : BusinessProcessBase
        {
            CN001CreateBranch _parent;

            #region Models 
            public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

            #endregion


            
            public UpdateBranch(CN001CreateBranch parent)
            {
                _parent = parent;
                InitializeDataViewAndUserFlow();

            }
            void InitializeDataViewAndUserFlow()
            {
               
                Relations.Add(Branch_, RelationType.InsertIfNotFound, Branch_.Id.IsEqualTo(_parent.V_BranchId), Branch_.SortByPkBranch);

                Columns.Add(Branch_.Id);
                Columns.Add(Branch_.Name);
                Columns.Add(Branch_.TelephoneNumber);
                Columns.Add(Branch_.OpenDate);
                Columns.Add(Branch_.Status);


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
                Branch_.Id.Value = _parent.V_BranchId;
                Branch_.Name.Value = _parent.V_BranchName.Value;
                Branch_.TelephoneNumber.Value = _parent.V_Telephone.Value;
                Branch_.OpenDate.Value = _parent.V_OpenDate;
                Branch_.Status.Value = 'A';


            }


        }

        //Begin GetLastID Class
        internal class GetLastID : BusinessProcessBase
        {
            CN001CreateBranch _parent;
            #region Models

            #endregion
            #region Columns
            public readonly NumberColumn V_MaxID = new NumberColumn("V_MaxID");
            public readonly NumberColumn V_temp = new NumberColumn("V_temp");
            #endregion

            //DynamicSQLEntity dynamicSql;
            public GetLastID(CN001CreateBranch parent)
            {
                var dynamicSql = new DynamicSQLEntity(Shared.DataSources.Oracle7, @"select Max(ID) from Branch ");


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