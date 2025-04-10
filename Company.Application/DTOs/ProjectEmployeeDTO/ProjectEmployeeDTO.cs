namespace Company.Application.DTOs.ProjectEmployeeDTO;

public class ProjectEmployeeDTO
{
    public Guid ProjectId { get; set; }
    public Guid EmployeeId { get; set; }
    public bool Enable { get; set; }
}