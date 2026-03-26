using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(String message) : base(message) { }
    }
}
