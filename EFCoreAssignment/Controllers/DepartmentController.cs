using Company.Application.Abstractions.Services;
using Company.Application.DTOs.DepartmentDTO;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var departments = await _departmentService.GetAllAsync();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var department = await _departmentService.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DepartmentRequestDTO department)
    {
        if (department == null)
        {
            return BadRequest();
        }
        var createdDepartment = await _departmentService.CreateAsync(department);
        return StatusCode(201, createdDepartment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] DepartmentRequestDTO department)
    {
        if (department == null)
        {
            return BadRequest();
        }
        try
        {
            await _departmentService.UpdateAsync(id, department);
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
            await _departmentService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
