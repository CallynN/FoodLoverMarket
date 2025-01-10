using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENV;

namespace EMS.Utilities
{
    public interface ICNNextNumber
    {
        void Run(TextParameter pP_Code, NumberParameter pP_Number);
    }
}
