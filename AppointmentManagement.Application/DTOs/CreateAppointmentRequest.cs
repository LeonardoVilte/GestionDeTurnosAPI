using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.DTOs
{
    public class CreateAppointmentRequest
    {
        public Guid ProfessionalId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
