namespace Company.Application.DTOs.EmployeeDTO;

public class EmployeeWithDepartmentResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly JoinedDate { get; set; }
    public string DepartmentName { get; set; }
}
