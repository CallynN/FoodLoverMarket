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
    public class CN002EditBranch : UIControllerBase, ICN002EditBranch
    {

        #region Models
        public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

        #endregion
        #region Columns 

        #endregion

        public CN002EditBranch()
        {
            Title = "CN002 Edit Branch";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {
            From = Branch_;

            #region Column Selection and UserFlow
            Columns.Add(Branch_.Id);
            Columns.Add(Branch_.Name);
            Columns.Add(Branch_.TelephoneNumber);
            Columns.Add(Branch_.Status);

            #endregion

        }


        public void Run()
        {
            Execute();
        }

        protected override void OnLoad()
        {
            AllowInsert = false;
            View = () => new Views.CN002EditBranchView(this);
        }
    }
}