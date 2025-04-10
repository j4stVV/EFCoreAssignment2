using Company.Domain.Entities;
using Company.Domain.Repositories;

namespace Company.Persistence.Repositories;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}