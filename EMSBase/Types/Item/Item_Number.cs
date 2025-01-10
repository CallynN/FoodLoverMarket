using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Item_Number(T#3)</summary>
    public class Item_Number : NumberColumn 
    {
        public Item_Number(string name = "Item_Number", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
