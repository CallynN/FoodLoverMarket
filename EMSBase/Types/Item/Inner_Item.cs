using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Inner_Item(T#13)</summary>
    public class Inner_Item : NumberColumn 
    {
        public Inner_Item(string name = "Inner_Item", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
