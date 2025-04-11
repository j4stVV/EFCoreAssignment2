using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Persistence.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(e => e.DepartmentId)
            .IsRequired();
        builder
            .Property(e => e.JoinedDate)
            .HasColumnType("date")
            .IsRequired();
           
        builder
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
        /*builder
            .HasOne(e => e.Salary)
            .WithOne(s => s.Employee)
            .HasForeignKey<Salary>(s => s.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);*/
        builder
            .HasMany(e => e.ProjectEmployees)
            .WithOne(pe => pe.Employee)
            .HasForeignKey(pe => pe.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Employee");
    }
}
