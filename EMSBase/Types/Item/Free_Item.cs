using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Free_Item(T#9)</summary>
    public class Free_Item : NumberColumn 
    {
        public Free_Item(string name = "Free_Item", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
