using Firefly.Box;
using ENV.Data;
namespace EMS.Types.Item
{
    /// <summary>FinalProduct(T#18)</summary>
    public class FinalProduct : NumberColumn 
    {
        public FinalProduct(string name = "FinalProduct", string format = "9", string caption = null) : base(name, format, caption)
        {
            DbType = "Number(9)";
        }
    }
}
