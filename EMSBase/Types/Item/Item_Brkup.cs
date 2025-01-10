using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Item_Brkup(T#14)</summary>
    public class Item_Brkup : NumberColumn 
    {
        public Item_Brkup(string name = "Item_Brkup", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
