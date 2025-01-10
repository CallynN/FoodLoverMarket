using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Models.MasterData
{
    public class Product : Entity
    {
        [PrimaryKey]
        public readonly NumberColumn Id = new NumberColumn("ID", "10");
        public readonly TextColumn Name = new TextColumn("Name", "100");
        public readonly BoolColumn WeightedItem = new BoolColumn("WeightedItem");
        public readonly NumberColumn SuggestedSellingPrice = new NumberColumn("SuggestedSellingPrice", "12.2");
        public readonly TextColumn Status = new TextColumn("Status", "U");

        #region Indexes
        public readonly Index SortByPKProduct = new Index { Name = "PK__Product__3214EC27E3F7275C", Unique = true };
        #endregion

        public Product() : base("Product", EMS.Shared.DataSources.Oracle7)
        {
            SortByPKProduct.Add(Id);
        }

    }
}
