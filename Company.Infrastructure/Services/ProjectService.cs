using AutoMapper;
using Company.Application.Abstractions.Services;
using Company.Application.DTOs.ProjectDTO;
using Company.Domain.Entities;
using Company.Domain.Repositories;

namespace Company.Infrastructure.Services;

public class ProjectService : ServiceBase<Project, ProjectResponseDTO, ProjectRequestDTO>, IProjectService
{
    public ProjectService(IRepository<Project> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
