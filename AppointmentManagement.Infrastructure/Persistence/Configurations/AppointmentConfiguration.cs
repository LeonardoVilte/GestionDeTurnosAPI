using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Persistence.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ProfessionalId)
            .IsRequired();

        builder.Property(a => a.ClientId)
            .IsRequired();

        builder.Property(a => a.StartDateTime)
            .IsRequired();

        builder.Property(a => a.EndDateTime)
            .IsRequired();

        builder.Property(a => a.Status)
            .IsRequired();

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        builder.Property(a => a.UpdatedAt);
    }
}