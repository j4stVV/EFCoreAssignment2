using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Persistence.EntityConfigurations;

public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
{
    public void Configure(EntityTypeBuilder<Salary> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.EmployeeId)
            .IsRequired();
        builder
            .Property(s => s.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder
            .HasOne(s => s.Employee)
            .WithOne(e => e.Salary)
            .HasForeignKey<Employee>(e => e.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Salary");
    }
}
