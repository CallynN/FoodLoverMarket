using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item_Product
{
    /// <summary>Item_Product(T#195)</summary>
    public class Item_Product_3 : NumberColumn 
    {
        public Item_Product_3(string name = "Item_Product", string format = "6", string caption = null) : base(name, format, caption)
        {
            DbType = "NUMBER(6)";
        }
    }
}
