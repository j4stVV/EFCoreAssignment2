using AutoMapper;
using Company.Application.Abstractions.Services;
using Company.Application.DTOs.ProjectEmployeeDTO;
using Company.Domain.Repositories;

namespace Company.Infrastructure.Services;

public class ProjectEmployeeService : IProjectEmployeeService
{
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;
    private readonly IMapper _mapper;

    public ProjectEmployeeService(IProjectEmployeeRepository projectEmployeeRepository, IMapper mapper)
    {
        _projectEmployeeRepository = projectEmployeeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectEmployeeDTO>> GetAllAsync()
    {
        var entites = await _projectEmployeeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProjectEmployeeDTO>>(entites);
    }

    public async Task<ProjectEmployeeDTO> GetByIdAsync(Guid projectId, Guid employeeId)
    {
        var entity = await _projectEmployeeRepository.GetAllAsync()
            .ContinueWith(t => t.Result.FirstOrDefault(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId));
        return _mapper.Map<ProjectEmployeeDTO>(entity);
    }

    public async Task<ProjectEmployeeDTO> CreateAsync(ProjectEmployeeDTO projectEmployee)
    {
        var entity = _mapper.Map<Domain.Entities.ProjectEmployee>(projectEmployee);
        await _projectEmployeeRepository.AddAsync(entity);
        await _projectEmployeeRepository.SaveChangesAsync();
        return _mapper.Map<ProjectEmployeeDTO>(entity);
    }

    public async Task UpdateAsync(Guid projectId, Guid employeeId, ProjectEmployeeDTO projectEmployee)
    {
        var entity = await _projectEmployeeRepository.GetAllAsync()
            .ContinueWith(t => t.Result.FirstOrDefault(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId));
        if (entity == null)
        {
            throw new KeyNotFoundException($"ProjectEmployee with Project ID {projectId} and Employee ID {employeeId} not found.");
        }
        _mapper.Map(projectEmployee, entity);
        _projectEmployeeRepository.Update(entity);
        await _projectEmployeeRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid projectId, Guid employeeId)
    {
        var entity = await _projectEmployeeRepository.GetAllAsync()
            .ContinueWith(t => t.Result.FirstOrDefault(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId));
        if (entity == null)
        {
            throw new KeyNotFoundException($"ProjectEmployee with Project ID {projectId} and Employee ID {employeeId} not found.");
        }
        _projectEmployeeRepository?.DeleteAsync(entity);
        await _projectEmployeeRepository.SaveChangesAsync();
    }
}
