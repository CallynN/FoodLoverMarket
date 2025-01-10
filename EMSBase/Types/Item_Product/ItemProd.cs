using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item_Product
{
    /// <summary>ItemProd(T#184)</summary>
    public class ItemProd : NumberColumn 
    {
        public ItemProd(string name = "ItemProd", string format = "6", string caption = null) : base(name, format, caption)
        {
            DbType = "NUMBER(6)";
        }
    }
}
