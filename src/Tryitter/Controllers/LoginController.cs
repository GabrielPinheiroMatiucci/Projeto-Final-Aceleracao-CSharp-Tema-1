using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Token;
using Tryitter.Models;
using Tryitter.Repository;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
  private readonly TryitterRepository _repository;

  public LoginController(TryitterRepository repository)
  {
    _repository = repository;
  }

  [HttpPost]
  [AllowAnonymous]
  public async Task<IActionResult> Login([FromBody] Credentials credentials)
  {
    if (credentials.Email == "email@email.com" && credentials.Password == "123")
    {
      Student student = await _repository.GetStudentAsync(2);
      string token = TokenGenerator.Generate(student);

      return Ok(token);
    }

    return NotFound();
  }
}
