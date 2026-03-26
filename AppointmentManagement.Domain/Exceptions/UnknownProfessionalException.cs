using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Exceptions;

    public class UnknownProfessionalException : Exception
    { 
        public UnknownProfessionalException(String message) : base(message)
    {}
}
