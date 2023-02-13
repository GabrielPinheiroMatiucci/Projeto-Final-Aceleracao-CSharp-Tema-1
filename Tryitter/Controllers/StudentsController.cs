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
    _repository.CreateStudent(student);

    return NoContent();
  }
}
