using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Promotion_Item(T#10)</summary>
    public class Promotion_Item : NumberColumn 
    {
        public Promotion_Item(string name = "Promotion_Item", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
