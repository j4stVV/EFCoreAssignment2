namespace Company.Application.DTOs.SalaryDTO;

public class SalaryResponseDTO
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public decimal Amount { get; set; }
}
