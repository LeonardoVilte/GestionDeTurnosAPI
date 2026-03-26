using AppointmentManagement.Domain.Enums;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Entities;

public class Professional
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string FullName { get; private set; }
    public bool IsActive { get; private set; }
    
    private readonly List<Availability> _availabilities = new();
    private readonly List<Appointment> _appointments = new();
    public IReadOnlyCollection<Availability> Availabilities => _availabilities.AsReadOnly();
    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();
    
    private Professional() { }

    public Professional(Guid userId, string fullName)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void AddAvailability(DayOfWeek dayOfWeek, TimeRange timeRange)
    {
        var existing = _availabilities
            .Where(a => a.DayOfWeek == dayOfWeek);

        foreach (var availability in existing)
        {
            if (availability.TimeRange.Overlaps(timeRange))
                throw new DomainException("Availability overlaps with existing availability.");
        }

        var newAvailability = new Availability(Id, dayOfWeek, timeRange);

        _availabilities.Add(newAvailability);
    }

    public Appointment ScheduleAppointment(Guid clientId, DateTime start, DateTime end)
    {
        if (!IsActive)
            throw new DomainException("Professional is inactive.");

        if (start >= end)
            throw new DomainException("Invalid appointment time range.");

        if (start < DateTime.UtcNow)
            throw new DomainException("Cannot schedule appointments in the past.");

        var appointmentRange = new TimeRange(start.TimeOfDay, end.TimeOfDay);

        var availability = _availabilities
            .FirstOrDefault(a => a.DayOfWeek == start.DayOfWeek);

        if (availability is null)
            throw new DomainException("Professional is not available on this day.");

        if (!availability.TimeRange.Contains(appointmentRange))
            throw new DomainException("Appointment is outside availability.");

        foreach (var existing in _appointments
                     .Where(a => a.Status == AppointmentStatus.Scheduled))
        {
            var existingRange = new TimeRange(
                existing.StartDateTime.TimeOfDay,
                existing.EndDateTime.TimeOfDay);

            if (existingRange.Overlaps(appointmentRange))
                throw new DomainException("Appointment overlaps with existing appointment.");
        }

        var appointment = new Appointment(Id, clientId, start, end);

        _appointments.Add(appointment);

        return appointment;
    }
}
