using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Persistence.Configurations;

public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.ToTable("Availabilities");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ProfessionalId)
            .IsRequired();

        builder.Property(a => a.DayOfWeek)
            .IsRequired();

        builder.OwnsOne(a => a.TimeRange, tr =>
        {
            tr.Property(p => p.Start)
                .HasColumnName("StartTime")
                .IsRequired();

            tr.Property(p => p.End)
                .HasColumnName("EndTime")
                .IsRequired();
        });
    }
}
