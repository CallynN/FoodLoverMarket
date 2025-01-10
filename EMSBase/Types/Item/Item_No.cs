using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Item_No(T#2)</summary>
    public class Item_No : NumberColumn 
    {
        public Item_No(string name = "Item_No", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
