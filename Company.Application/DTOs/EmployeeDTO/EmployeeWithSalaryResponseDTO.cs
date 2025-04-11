namespace Company.Application.DTOs.EmployeeDTO;

public class EmployeeWithSalaryResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly JoinedDate { get; set; }
    public Guid DepartmentId { get; set; }
    public decimal Amount { get; set; }
}
