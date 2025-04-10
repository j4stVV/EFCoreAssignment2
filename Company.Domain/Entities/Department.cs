namespace Company.Domain.Entities;

public class Department : Entity
{
    public required string Name { get; set; }
    public ICollection<Employee> ?Employees { get; set; }
}
