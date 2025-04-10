namespace Company.Domain.Entities;

public class Employee : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public DateOnly JoinedDate { get; set; }

    public Department Department { get; set; }
    public Salary Salary { get; set; }
    public ICollection<ProjectEmployee> ProjectEmployees { get; set; }

}
