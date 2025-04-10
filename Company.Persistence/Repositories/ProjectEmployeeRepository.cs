using Company.Domain.Entities;
using Company.Domain.Repositories;

namespace Company.Persistence.Repositories;

public class ProjectEmployeeRepository : Repository<ProjectEmployee>, IProjectEmployeeRepository
{
    public ProjectEmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
