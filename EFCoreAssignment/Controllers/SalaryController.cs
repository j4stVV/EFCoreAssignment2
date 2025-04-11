using Company.Application.Abstractions.Services;
using Company.Application.DTOs.SalaryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SalaryController : ControllerBase
{
    private readonly ISalaryService _salaryService;

    public SalaryController(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var salaries = await _salaryService.GetAllAsync();
        return Ok(salaries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var salary = await _salaryService.GetByIdAsync(id);
        if (salary == null)
        {
            return NotFound();
        }
        return Ok(salary);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SalaryRequestDTO salaryRequest)
    {
        if (salaryRequest == null)
        {
            return BadRequest("Salary data is required.");
        }
        var createdSalary = await _salaryService.CreateAsync(salaryRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdSalary.Id }, createdSalary);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SalaryRequestDTO salaryRequest)
    {
        if (salaryRequest == null)
        {
            return BadRequest("Salary data is required.");
        }
        try
        {
            await _salaryService.UpdateAsync(id, salaryRequest);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
