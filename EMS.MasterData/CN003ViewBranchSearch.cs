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
    public class CN003ViewBranchSearch : FlowUIControllerBase, ICN003ViewBranchSearch
    {

        #region Columns
        public readonly TextColumn V_Status = new TextColumn("V_Status","U") { InputRange = "A,D,B" };
        public readonly TextColumn V_Accept = new TextColumn("V_Accept", "U") { InputRange = "Y,N" };
        #endregion

        public CN003ViewBranchSearch()
        {
            Title = "CN003 View Branch Search";
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
            View = () => new Views.CN003ViewBranchSearchView(this);
        }

        protected override void OnLeaveRow()
        {
            if (V_Accept == 'Y')
            {
                Create<CN004ViewBranch>().Run(V_Status);
            }

            
        }

    }
}