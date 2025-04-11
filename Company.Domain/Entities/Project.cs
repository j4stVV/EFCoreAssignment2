namespace Company.Domain.Entities;

public class Project : Entity
{
    public string Name { get; set; } = string.Empty;
    public required ICollection<ProjectEmployee> ProjectEmployees { get; set; }
}
