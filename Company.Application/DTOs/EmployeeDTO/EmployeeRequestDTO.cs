namespace Company.Application.DTOs.EmployeeDTO;

public class EmployeeRequestDTO
{
    public string Name { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public DateOnly JoinedDate { get; set; }
}
