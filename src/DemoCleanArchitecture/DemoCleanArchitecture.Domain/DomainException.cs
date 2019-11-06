using System;

namespace DemoCleanArchitecture.Domain
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage)
            : base(businessMessage)
        {
        }

        internal static void When(bool HasError, string message)
        {
            if (HasError)
                throw new Exception(message);
        }
    }
}
