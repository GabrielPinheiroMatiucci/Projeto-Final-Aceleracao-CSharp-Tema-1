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

  [HttpGet("post")] /* talvez faria o caminho como sendo: student/id/post */
  public IActionResult GetPosts(int id) /* ainda na dúvida se deeveria colocar o id do student */
  {
    return Ok(_repository.GetPosts(id));
  }

  [HttpGet]
  public IActionResult GetLastPost(int id)
  {
    return Ok(_repository.GetLastPost(id));
  }

  // [HttpPost]
  // public IActionResult CreatePost(int id, Post post)
  // {
  //   return Ok(_repository.CreatePost(id, post));
  // }
  //   [HttpPost]
  // public IActionResult 
  // {
  // return Ok(_repository.);

  // }

  // [HttpGet]
  // public IActionResult
  // {
  // return Ok(_repository.);
  // 
  // }

  // [HttpGet]
  // public IActionResult
  // {
  // return Ok(_repository.);
  // 
  // }

}