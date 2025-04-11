using Company.Application.Abstractions.Services;
using Company.Application.DTOs.EmployeeDTO;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeRequestDTO employeeRequest)
    {
        if (employeeRequest == null)
        {
            return BadRequest("Employee data is required.");
        }
        var createdEmployee = await _employeeService.CreateAsync(employeeRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeRequestDTO employeeRequest)
    {
        if (employeeRequest == null)
        {
            return BadRequest("Employee data is required.");
        }
        try
        {
            await _employeeService.UpdateAsync(id, employeeRequest);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("with-department")]
    public async Task<IActionResult> GetAllWithDepartment()
    {
        var employeesWithDepartment = await _employeeService.GetAllWithDepartmentAsync();
        return Ok(employeesWithDepartment);
    }

    [HttpGet("with-projects")]
    public async Task<IActionResult> GetAllWithProjects()
    {
        var employeesWithProjects = await _employeeService.GetAllWithProjectsAsync();
        return Ok(employeesWithProjects);
    }

    [HttpGet("with-salary")]
    public async Task<IActionResult> GetAllWithSalary()
    {
        var minSalary = 10m; // Salary > 100
        var minJoinedDate = new DateOnly(2024, 1, 1); // JoinedDate >= 01/01/2024
        var employees = await _employeeService.GetEmployeesBySalaryAndJoinedDateAsync(minSalary, minJoinedDate);
        return Ok(employees);
    }
}
