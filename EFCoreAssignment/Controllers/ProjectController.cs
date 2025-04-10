using AutoMapper;
using Company.Application.Abstractions.Services;
using Company.Application.DTOs.DepartmentDTO;
using Company.Application.DTOs.ProjectDTO;
using Company.Domain.Entities;
using Company.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;
    public ProjectController(IProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var project = await _projectService.GetByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectRequestDTO project)
    {
        if (project == null)
        {
            return BadRequest();
        }
        var createdProject = await _projectService.CreateAsync(project);
        return StatusCode(201, createdProject);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProjectRequestDTO project)
    {
        if (project == null)
        {
            return BadRequest();
        }
        try
        {
            await _projectService.UpdateAsync(id, project);
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
            await _projectService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
