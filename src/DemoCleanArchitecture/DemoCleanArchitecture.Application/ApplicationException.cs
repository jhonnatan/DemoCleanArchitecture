using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCleanArchitecture.Application
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
