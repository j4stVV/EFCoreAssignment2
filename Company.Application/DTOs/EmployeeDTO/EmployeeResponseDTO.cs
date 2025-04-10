namespace Company.Application.DTOs.EmployeeDTO;

public class EmployeeResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public DateOnly JoinedDate { get; set; }
}
