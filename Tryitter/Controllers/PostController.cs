using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
  private readonly TryitterRepository _repository;

  public PostController(TryitterRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  public IActionResult GetPost()
  {
    return Ok(_repository.GetPost());
  }
}