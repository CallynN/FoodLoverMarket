using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Variant_Item_No(T#17)</summary>
    public class Variant_Item_No : NumberColumn 
    {
        public Variant_Item_No(string name = "Variant_Item_No", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
