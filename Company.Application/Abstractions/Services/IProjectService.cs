using Company.Application.DTOs.ProjectDTO;
using Company.Domain.Entities;

namespace Company.Application.Abstractions.Services;

public interface IProjectService : IServiceBase<Project, ProjectResponseDTO, ProjectRequestDTO>
{
}