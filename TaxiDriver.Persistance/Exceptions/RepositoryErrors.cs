using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDriver.Persistance.Exceptions
{
    public class RepositoryErrors : Exception
    {
        public RepositoryErrors() { }
        public RepositoryErrors(string message) 
            : base(message){ }

        public RepositoryErrors(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
