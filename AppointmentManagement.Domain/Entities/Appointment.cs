using AppointmentManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid ProfessionalId { get; private set; }
    public Guid ClientId { get; private set; }

    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    public AppointmentStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Appointment() { }

    public Appointment(
        Guid professionalId,
        Guid clientId,
        DateTime startDateTime,
        DateTime endDateTime)
    {
        if (startDateTime >= endDateTime)
            throw new ArgumentException("StartDateTime must be before EndDateTime.");

        Id = Guid.NewGuid();
        ProfessionalId = professionalId;
        ClientId = clientId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = AppointmentStatus.Scheduled;
        CreatedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        if (Status == AppointmentStatus.Completed)
            throw new InvalidOperationException("Completed appointments cannot be cancelled.");

        Status = AppointmentStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        if (Status != AppointmentStatus.Scheduled)
            throw new InvalidOperationException("Only scheduled appointments can be completed.");

        Status = AppointmentStatus.Completed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Reschedule(DateTime newStart, DateTime newEnd)
    {
        if (Status != AppointmentStatus.Scheduled)
            throw new InvalidOperationException("Only scheduled appointments can be rescheduled.");

        if (newStart >= newEnd)
            throw new ArgumentException("Invalid date range.");

        StartDateTime = newStart;
        EndDateTime = newEnd;
        UpdatedAt = DateTime.UtcNow;
    }
}
