using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Domain.Exceptions
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string message) : base(message)
        {
        }

        public static void When(bool condition, string message) 
        {
            if (condition)
            {
                throw new DomainValidation(message);
            }
        }
    }
}
