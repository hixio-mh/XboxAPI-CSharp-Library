using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxAPI.Exceptions
{
    public class BadAPIKeyException : Exception
    {
        public BadAPIKeyException(string key) : base($"The key {key} was invalid.")
        {
        }
    }
}
