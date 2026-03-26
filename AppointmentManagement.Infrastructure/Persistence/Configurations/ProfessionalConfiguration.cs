using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Infrastructure.Persistence.Configurations;
public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
{
    public void Configure(EntityTypeBuilder<Professional> builder)
    {
        builder.ToTable("Professionals");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FullName)
            .IsRequired()
            .HasMaxLength(200);

        // Relationship with Appointments
        builder.HasMany(p => p.Appointments)
            .WithOne()
            .HasForeignKey(a => a.ProfessionalId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationship with Availabilities
        builder.HasMany(p => p.Availabilities)
            .WithOne()
            .HasForeignKey(a => a.ProfessionalId)
            .OnDelete(DeleteBehavior.Cascade);

        // Backing fields configuration (CRITICAL for aggregate root)
        builder.Metadata
            .FindNavigation(nameof(Professional.Appointments))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Professional.Availabilities))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}