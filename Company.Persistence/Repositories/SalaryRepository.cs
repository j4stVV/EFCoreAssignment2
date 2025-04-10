using Company.Domain.Entities;
using Company.Domain.Repositories;

namespace Company.Persistence.Repositories;

public class SalaryRepository : Repository<Salary>, ISalaryRepository
{
    public SalaryRepository(ApplicationDbContext context) : base(context)
    {
    }
}