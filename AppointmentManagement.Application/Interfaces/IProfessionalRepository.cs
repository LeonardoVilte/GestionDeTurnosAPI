using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Entities;

namespace AppointmentManagement.Application.Interfaces;

    public interface IProfessionalRepository
    {
        Task<Professional?> GetByIdAsync(Guid id, bool includeDetails = false);
        Task SaveAsync(Professional professional);
    }

