using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Enums;

public enum AppointmentStatus
{
    //Programada
    Scheduled = 1,
    //Cancelada
    Cancelled = 2,
    //Completada
    Completed = 3,
    //No visible
    NoShow = 4

}
