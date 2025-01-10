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
    public class CN004ViewBranch : FlowUIControllerBase
    {
        #region Models 
        public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

        #endregion
        #region Columns 
        public readonly TextColumn P_Status = new TextColumn("P_Status","U");
        #endregion

        public CN004ViewBranch()
        {
            Title = "CN004 View Branch";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {
            From = Branch_;
            Debug.WriteLine(P_Status);

           
            Where.Add(Branch_.Status.IsEqualTo(P_Status));
            
            

            #region Column Selection and UserFlow
            Columns.Add(Branch_.Id);
            Columns.Add(Branch_.Name);
            Columns.Add(Branch_.TelephoneNumber);
            Columns.Add(Branch_.Status);

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
            View = () => new Views.CN004ViewBranchView(this);
        }
    }
}