using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item_Product
{
    /// <summary>Product(T#182)</summary>
    public class Product : NumberColumn 
    {
        public Product(string name = "Product", string format = "6", string caption = null) : base(name, format, caption)
        {
            DbType = "NUMBER(6)";
        }
    }
}
