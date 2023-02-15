using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Interfaces;
using Tryitter.Models;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
  private readonly ITryitterRepository _repository;

  public PostsController(ITryitterRepository repository)
  {
    _repository = repository;
  }

  // [HttpGet("{id}")] /* talvez faria o caminho como sendo: student/id/post */
  // public async Task<IActionResult> GetAllPostsAsync(int id)
  // {
  //   return Ok(await _repository.GetAllPostsAsync(id));
  // }

  [HttpGet]
  public async Task<IActionResult> GetAllPostsAsync()
  {
    return Ok(await _repository.GetAllPostsAsync());
  }


  [AllowAnonymous]
  [HttpGet("{id}")]

  public async Task<IActionResult> GetPostByIdAsync([FromRoute] int id)
  {
    Post? post = await _repository.GetPostByIdAsync(id);

    if (post == null)
      return NotFound();

    return Ok(post);
  }

  [HttpGet]
  public async Task<IActionResult> GetLastPostAsync(int id)
  {
    var post = _repository.GetLastPostAsync(id);
    if (post == null) return NotFound();
    return Ok(post);
  }

  [HttpPost]
  [Authorize("Login")]

  public IActionResult CreatePost([FromBody] Post post)
  {
    int id = _repository.CreatePost(post);
    return Created($"/posts/{id}", post);
  }


  [HttpPost]
  [HttpPut("{id}")]
  [Authorize("Login")]
  public IActionResult UpdatePost([FromBody] int postId, Post newPost)
  {
    if (_repository.UpdatePost(postId, newPost))
      return NoContent();

    return BadRequest();

  }

  [HttpGet]
  public async Task<IActionResult> DeletePostAsync([FromBody] int postId)
  {
    bool post = await _repository.DeletePostAsync(postId);

    if (!post)
      return NotFound();

    return NoContent();

  }
}