using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Persistence.EntityConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        /*builder
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);*/

        builder.ToTable("Department");

        //Seed data
        builder.HasData(
            new Department { Id = new Guid("550e8400-e29b-41d4-a716-446655440000"), Name = "Software Development" },
            new Department { Id = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8"), Name = "Finance" },
            new Department { Id = new Guid("e2c2b8f0-3d5e-4f2a-9c1b-7d8e9f6a5b3c"), Name = "Accountant" },
            new Department { Id = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), Name = "HR" }
        );
    }
}
