using AppointmentManagement.Application.DTOs;
using AppointmentManagement.Application.Interfaces;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.Entities;
using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Application.Services;

public class AppointmentService
{
    private readonly IProfessionalRepository _professionalRepository;

    public AppointmentService(IProfessionalRepository professionalRepository)
    {
        _professionalRepository = professionalRepository;
    }

    public async Task<Guid> CreateAsync(CreateAppointmentRequest request)
    {
        var professional = await _professionalRepository
            .GetByIdAsync(request.ProfessionalId, includeDetails: true);

        if (professional is null)
            throw new UnknownProfessionalException("Professional not found.");

        var appointment = professional.ScheduleAppointment(
            request.ClientId,
            request.StartDateTime,
            request.EndDateTime);

        await _professionalRepository.SaveAsync(professional);

        return appointment.Id;
    }
}
