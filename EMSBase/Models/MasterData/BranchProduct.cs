using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Models.MasterData
{
    public class BranchProduct : Entity
    {
        [PrimaryKey]
        public readonly NumberColumn BranchID = new NumberColumn("BranchID", "10");
        [PrimaryKey]
        public readonly NumberColumn ProductID = new NumberColumn("ProductID", "10");

        #region Indexes
        public readonly Index SortByPKBranch = new Index { Name = "PKBranch", Unique = true };
        #endregion

        public BranchProduct() : base("Branch_Product", EMS.Shared.DataSources.Oracle7)
        {
            SortByPKBranch.Add(BranchID, ProductID);
        }

    }
}
