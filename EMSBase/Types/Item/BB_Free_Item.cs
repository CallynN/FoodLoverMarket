using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>BB_Free_Item(T#11)</summary>
    public class BB_Free_Item : NumberColumn 
    {
        public BB_Free_Item(string name = "BB_Free_Item", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
