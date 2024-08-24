using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Exceptions
{
    internal class AccessedByAdminException:Exception
    {
        public AccessedByAdminException(string message):base(message)
        {
            
        }
    }
}
