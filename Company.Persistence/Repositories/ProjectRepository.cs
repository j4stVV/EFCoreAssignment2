using Company.Domain.Entities;
using Company.Domain.Repositories;

namespace Company.Persistence.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
    }
}
