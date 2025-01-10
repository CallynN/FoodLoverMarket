using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Item(T#1)</summary>
    public class Item : NumberColumn 
    {
        public Item(string name = "Item", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
