using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Infrastructure.Persistence;

public class AppointmentDbContext : DbContext
{
    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
        : base(options)
    {
    }

    public DbSet<Professional> Professionals => Set<Professional>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Availability> Availabilities => Set<Availability>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentDbContext).Assembly);
    }
}

