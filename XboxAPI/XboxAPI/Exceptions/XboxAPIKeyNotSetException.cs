using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxAPI.Exceptions
{
    public class XboxAPIKeyNotSetException : Exception
    {
        public XboxAPIKeyNotSetException() : base("You need to set an API key before using this library. Use SetXboxAPIKey()")
        {
        }
    }
}
