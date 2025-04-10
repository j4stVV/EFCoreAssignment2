namespace Company.Application.DTOs;

public class SalaryDTO
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public decimal Amount { get; set; }
}
