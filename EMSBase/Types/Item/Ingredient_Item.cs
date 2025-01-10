using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>Ingredient_Item(T#5)</summary>
    public class Ingredient_Item : NumberColumn 
    {
        public Ingredient_Item(string name = "Ingredient_Item", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
