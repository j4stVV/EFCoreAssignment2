using Company.Application.Abstractions.Services;
using Company.Application.DTOs.ProjectEmployeeDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectEmployeeController : ControllerBase
{
    private readonly IProjectEmployeeService _projectEmployeeService;

    public ProjectEmployeeController(IProjectEmployeeService projectEmployeeService)
    {
        _projectEmployeeService = projectEmployeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projectEmployees = await _projectEmployeeService.GetAllAsync();
        return Ok(projectEmployees);
    }

    [HttpGet("{projectId}/{employeeId}")]
    public async Task<IActionResult> GetById(Guid projectId, Guid employeeId)
    {
        var projectEmployee = await _projectEmployeeService.GetByIdAsync(projectId, employeeId);
        if (projectEmployee == null)
        {
            return NotFound();
        }
        return Ok(projectEmployee);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectEmployeeDTO projectEmployee)
    {
        if (projectEmployee == null)
        {
            return BadRequest();
        }
        var createdProjectEmployee = await _projectEmployeeService.CreateAsync(projectEmployee);
        return StatusCode(201, createdProjectEmployee);
    }

    [HttpPut("{projectId}/{employeeId}")]
    public async Task<IActionResult> Update(Guid projectId, Guid employeeId, [FromBody] ProjectEmployeeDTO projectEmployee)
    {
        if (projectEmployee == null)
        {
            return BadRequest();
        }
        try
        {
            await _projectEmployeeService.UpdateAsync(projectId, employeeId, projectEmployee);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{projectId}/{employeeId}")]
    public async Task<IActionResult> Delete(Guid projectId, Guid employeeId)
    {
        try
        {
            await _projectEmployeeService.DeleteAsync(projectId, employeeId);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
