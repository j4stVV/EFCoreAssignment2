namespace Company.Application.DTOs.SalaryDTO;

public class SalaryRequestDTO
{
    public Guid EmployeeId { get; set; }
    public decimal Amount { get; set; }
}
