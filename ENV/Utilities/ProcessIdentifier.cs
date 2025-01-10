using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENV.Utilities
{
    public static class ProcessIdentifier
    {
        public static string sessionId;

        public static string GetSession()
        {
            Guid g = Guid.NewGuid();
            sessionId = g.ToString();
            return sessionId;
        }
    }
}
