using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Interfaces;
using Tryitter.Models;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
  private readonly ITryitterRepository _repository;

  public StudentsController(ITryitterRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  [AllowAnonymous]
  public async Task<IActionResult> GetStudentsAsync()
  {
    return Ok(await _repository.GetStudentsAsync());
  }

  [HttpGet("{id}")]
  [AllowAnonymous]
  public async Task<IActionResult> GetStudentAsync([FromRoute] int id)
  {
    Student? student = await _repository.GetStudentAsync(id);

    if (student == null)
      return NotFound();

    return Ok(student);
  }

  [HttpPost]
  [Authorize("Login")]
  public IActionResult CreateStudent([FromBody] Student student)
  {
    int id = _repository.CreateStudent(student);

    return Created($"/students/{id}", student);
  }

  [HttpPut("{id}")]
  [Authorize("Login")]
  public IActionResult UpdateStudent(
    [FromRoute] int id, [FromBody] Student student
  )
  {
    if (_repository.UpdateStudent(id, student))
      return NoContent();

    return BadRequest();
  }

  [HttpDelete("{id}")]
  [Authorize("Login")]
  public async Task<IActionResult> DeleteStudentAsync([FromRoute] int id)
  {
    bool student = await _repository.DeleteStudentAsync(id);

    if (!student)
      return NotFound();

    return NoContent();
  }
}
