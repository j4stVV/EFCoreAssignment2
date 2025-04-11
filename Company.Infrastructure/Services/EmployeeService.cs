using AutoMapper;
using Company.Application.Abstractions.Services;
using Company.Application.DTOs.EmployeeDTO;
using Company.Domain.Entities;
using Company.Domain.Repositories;

namespace Company.Infrastructure.Services;

public class EmployeeService : ServiceBase<Employee, EmployeeResponseDTO, EmployeeRequestDTO>, IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;
    private readonly ISalaryRepository _salaryRepository;
    private readonly IMapper _mapper;
    public EmployeeService(IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository,
        IProjectRepository projectRepository,
        IProjectEmployeeRepository projectEmployeeRepository,
        ISalaryRepository salaryRepository,
        IMapper mapper)
        : base(employeeRepository, mapper)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _projectEmployeeRepository = projectEmployeeRepository;
        _projectRepository = projectRepository;
        _salaryRepository = salaryRepository;
        _mapper = mapper;
    }

    public override async Task<EmployeeResponseDTO> CreateAsync(EmployeeRequestDTO employeeRequest)
    {
        var departmemt = await _departmentRepository.GetByIdAsync(employeeRequest.DepartmentId) 
            ?? throw new KeyNotFoundException($"Department with Id {employeeRequest.DepartmentId} not found");
        var employee = _mapper.Map<Employee>(employeeRequest);

        employee.Id = Guid.NewGuid();
        await _employeeRepository.AddAsync(employee);
        await _employeeRepository.SaveChangesAsync();
        return _mapper.Map<EmployeeResponseDTO>(employee);
    }

    public async Task<IEnumerable<EmployeeWithDepartmentResponseDTO>> GetAllWithDepartmentAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        var departments = await _departmentRepository.GetAllAsync();

        var result = from emp in employees
                     join dept in departments on emp.DepartmentId equals dept.Id
                     select new EmployeeWithDepartmentResponseDTO
                     {
                         Id = emp.Id,
                         Name = emp.Name,
                         JoinedDate = emp.JoinedDate,
                         DepartmentName = dept.Name
                     };
        return result;
    }

    public async Task<IEnumerable<EmployeeWithProjectsResponseDTO>> GetAllWithProjectsAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        var projectEmployees = await _projectEmployeeRepository.GetAllAsync();
        var projects = await _projectRepository.GetAllAsync();

        var result = from emp in employees
                     join pe in projectEmployees on emp.Id equals pe.EmployeeId into empProjects
                     from pe in empProjects.DefaultIfEmpty() // Left join với ProjectEmployee
                     join proj in projects on (pe != null ? pe.ProjectId : (Guid?)null) equals proj?.Id into projGroup
                     from proj in projGroup.DefaultIfEmpty() // Left join với Project
                     group new { pe, proj } by emp into grouped
                     select new EmployeeWithProjectsResponseDTO
                     {
                         Id = grouped.Key.Id,
                         Name = grouped.Key.Name,
                         JoinedDate = grouped.Key.JoinedDate,
                         DepartmentId = grouped.Key.DepartmentId,
                         Projects = grouped
                             .Where(g => g.pe != null && g.proj != null)
                             .Select(g => new ProjectInfor
                             {
                                 Id = g.proj.Id,
                                 ProjectName = g.proj.Name,
                                 Enable = g.pe.Enable
                             }).ToList()
                     };

        return result;
    }

    public async Task<IEnumerable<EmployeeWithSalaryResponseDTO>> GetEmployeesBySalaryAndJoinedDateAsync(decimal minSalary, DateOnly minJoinedDate)
    {
        var employees = await _employeeRepository.GetAllAsync();
        var salaries = await _salaryRepository.GetAllAsync();

        var result = from emp in employees
                     join sal in salaries on emp.Id equals sal.EmployeeId // Inner join để lấy Employee có Salary
                     where sal.Amount > minSalary && emp.JoinedDate >= minJoinedDate
                     select new EmployeeWithSalaryResponseDTO
                     {
                         Id = emp.Id,
                         Name = emp.Name,
                         JoinedDate = emp.JoinedDate,
                         DepartmentId = emp.DepartmentId,
                         Amount = sal.Amount
                     };

        return result;
    }
}
