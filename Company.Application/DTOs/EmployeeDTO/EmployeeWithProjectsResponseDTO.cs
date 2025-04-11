using Company.Application.DTOs.ProjectDTO;

namespace Company.Application.DTOs.EmployeeDTO;

public class EmployeeWithProjectsResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly JoinedDate { get; set; }
    public Guid DepartmentId { get; set; }
    public List<ProjectInfor> Projects { get; set; } = new();
}

public class ProjectInfor
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public bool Enable { get; set; }
}
