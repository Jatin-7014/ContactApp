using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Exceptions
{
    internal class TaskCannotPerformException:Exception
    {
        public TaskCannotPerformException(string message):base(message)
        {
            
        }
    }
}
