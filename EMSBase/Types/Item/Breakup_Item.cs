using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Breakup_Item(T#7)</summary>
    public class Breakup_Item : NumberColumn 
    {
        public Breakup_Item(string name = "Breakup_Item", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
