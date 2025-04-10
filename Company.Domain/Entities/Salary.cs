namespace Company.Domain.Entities;

public class Salary : Entity
{
    public Guid EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public Employee Employee { get; set; }
}
