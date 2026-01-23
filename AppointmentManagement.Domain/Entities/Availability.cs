using AppointmentManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Entities;

public class Availability
{
    public Guid Id { get; private set; }
    public Guid ProfessionalId { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeRange TimeRange { get; private set; }

    private Availability() { }

    public Availability(Guid professionalId, DayOfWeek dayOfWeek, TimeRange timeRange)
    {
        Id = Guid.NewGuid();
        ProfessionalId = professionalId;
        DayOfWeek = dayOfWeek;
        TimeRange = timeRange ?? throw new ArgumentNullException(nameof(timeRange));
    }
}