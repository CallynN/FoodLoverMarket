using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firefly.Box;
using ENV.Data;

namespace EMS.Models.MasterData
{
    public class Branch : Entity
    {

            [PrimaryKey]
            public readonly NumberColumn Id = new NumberColumn("ID", "10");
            public readonly TextColumn Name = new TextColumn("Name", "100");
            public readonly TextColumn TelephoneNumber = new TextColumn("TelephoneNumber", "15") { AllowNull = true };
            public readonly DateColumn OpenDate = new DateColumn("OpenDate") { Storage = new ENV.Data.Storage.DateTimeDateStorage() };
            public readonly TextColumn Status = new TextColumn("Status", "U");

        #region Indexes
        public readonly Index SortByPkBranch = new Index { Name = "PK__Branch__3214EC27FE3E33B1", Unique = true };
        #endregion

        public Branch() : base("Branch", EMS.Shared.DataSources.Oracle7)
        {
            SortByPkBranch.Add(Id);
        }
    }

    
}
