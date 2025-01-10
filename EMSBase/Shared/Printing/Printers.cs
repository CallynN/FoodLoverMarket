using ENV.Printing;
namespace EMS.Shared.Printing
{
    public class Printers
    {
        static Printers()
        {
        }
        /// <summary>Printer1</summary>
        public static readonly Printer Printer1 = new Printer("Printer1");
        /// <summary>Printer2</summary>
        public static readonly Printer Printer2 = new Printer("Printer2");
    }
}
