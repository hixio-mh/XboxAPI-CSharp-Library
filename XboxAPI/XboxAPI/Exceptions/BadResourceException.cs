using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxAPI.Exceptions
{
    public class BadResourceException : Exception
    {
        public BadResourceException() : base("The resource you attempted to access was not found!")
        {
        }
    }
}
