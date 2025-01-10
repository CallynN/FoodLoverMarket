using ENV;
using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EMS.MasterData
{
    public class CN007ViewProductsSearch : FlowUIControllerBase, ICN007ViewProductSearch
    {
        #region Columns
        public readonly TextColumn V_Status = new TextColumn("V_Status", "U") { InputRange = "A,D,B" };
        public readonly TextColumn V_Accept = new TextColumn("V_Accept", "U") { InputRange = "Y,N" };
        #endregion
        public CN007ViewProductsSearch()
        {
            Title = "CN007 View Product Search";
            InitializeDataViewAndUserFlow();
        }
        void InitializeDataViewAndUserFlow()
        {
            #region Column Selection and UserFlow 

            Columns.Add(V_Status);
            Columns.Add(V_Accept).BindValue(() => "N");

            #endregion
        }

        public void Run()
        {
            Execute();
        }

        protected override void OnLoad()
        {
            Exit(ExitTiming.AfterRow);
            BindGoToToNextRowAfterLastControl(() => !(V_Accept == "N"));
            View = () => new Views.CN007ViewProductsSearchView(this);
        }

        protected override void OnLeaveRow()
        {
            if (V_Accept == 'Y')
            {
                Create<CN008ViewProducts>().Run(V_Status);
            }


        }


    }
}