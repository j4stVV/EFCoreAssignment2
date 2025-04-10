namespace Company.Domain.Entities;

public class Project : Entity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
}
