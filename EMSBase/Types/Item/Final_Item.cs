using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Final_Item(T#6)</summary>
    public class Final_Item : NumberColumn 
    {
        public Final_Item(string name = "Final_Item", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
