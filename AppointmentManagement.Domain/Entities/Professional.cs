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
}
