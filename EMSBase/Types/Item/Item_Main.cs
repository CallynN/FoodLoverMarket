using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Item_Main(T#15)</summary>
    public class Item_Main : NumberColumn 
    {
        public Item_Main(string name = "Item_Main", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
