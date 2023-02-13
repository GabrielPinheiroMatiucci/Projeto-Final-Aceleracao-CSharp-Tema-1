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
  public IActionResult GetStudents()
  {
    return Ok(_repository.GetStudents());
  }

  [HttpPost]
  public IActionResult CreateStudent([FromBody] Student student)
  {
    int id = _repository.CreateStudent(student);

    return Created($"/students/{id}", student);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateStudent(
    [FromRoute] int id, [FromBody] Student student
  )
  {
    if (_repository.UpdateStudent(id, student))
      return NoContent();

    return BadRequest();
  }
}
