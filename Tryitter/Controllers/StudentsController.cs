using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;
using Tryitter.Repository;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
  private readonly TryitterRepository _repository;

  public StudentsController(TryitterRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  [AllowAnonymous]
  public IActionResult GetStudents()
  {
    return Ok(_repository.GetStudents());
  }

  [HttpGet("{id}")]
  [AllowAnonymous]
  public IActionResult GetStudent([FromRoute] int id)
  {
    Student? student = _repository.GetStudent(id);

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
  public IActionResult DeleteStudent([FromRoute] int id)
  {
    bool student = _repository.DeleteStudent(id);

    if (!student)
      return NotFound();

    return NoContent();
  }
}
