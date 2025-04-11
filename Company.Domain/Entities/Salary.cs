namespace Company.Domain.Entities;

public class Salary : Entity
{
    public Guid EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public required Employee Employee { get; set; }
}
