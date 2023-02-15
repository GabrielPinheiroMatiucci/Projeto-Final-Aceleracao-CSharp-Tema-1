using Tryitter.Models;
using Tryitter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Tryitter.Repository;

public class TryitterRepository : ITryitterRepository
{
  private readonly TryitterContext _context;

  public TryitterRepository(TryitterContext context)
  {
    _context = context;
  }

  public async Task<List<Student>>? GetStudentsAsync()
  {
    return await _context.Students.ToListAsync();
  }

  public async Task<Student>? GetStudentAsync(int id)
  {
    return await _context.Students.FirstOrDefaultAsync(student => student.Id == id);
  }

  public int CreateStudent(Student student)
  {
    _context.Students.Add(student);
    _context.SaveChanges();

    return student.Id;
  }

  public bool UpdateStudent(int id, Student student)
  {
    if (!_context.Students.Any(std => std.Id == id) || id != student.Id)
      return false;

    _context.Students.Update(student);
    _context.SaveChanges();

    return true;
  }

  public async Task<bool> DeleteStudentAsync(int id)
  {
    Student? student = await GetStudentAsync(id);

    if (student == null)
      return false;

    _context.Students.Remove(student);
    _context.SaveChanges();

    return true;
  }

  // CRUD Post
  public virtual async Task<List<Post>>? GetAllPostsAsync(int id)
  {
    var postsResult = await _context.Posts.Where(post => post.Id == id).ToListAsync();

    return postsResult;
  }
  // public virtual async Task<IEnumerable<Post>>? GetAllPostsAsync()
  // {
  //   var postsResult = await _context.Posts.ToListAsync();

  //   return postsResult;
  // }
  public async Task<Post?> GetPostByIdAsync(int postId)
  {
    var resultPost = await _context.Posts.FindAsync(postId);
    return resultPost;
  }

  // deveria ser async?? 
  public virtual async Task<Post?> GetLastPostAsync(int id) /* esse id é do student */
  {
    var postsResult = _context.Posts.Where(post => post.Id == id).ToList();
    var lastIndex = postsResult.Count - 1;

    return postsResult[lastIndex];
  }

  public virtual int CreatePost(Post post)
  {
    _context.Posts.Add(post);
    _context.SaveChanges();

    return post.PostId;
  }

  public virtual bool UpdatePost(int postId, Post newPost)
  {
    var resultPost = GetPostByIdAsync(postId);
    if (resultPost == null) return false;

    _context.Posts.Update(newPost);
    _context.SaveChanges();

    return true;
  }

  public async Task<bool> DeletePostAsync(int postId)
  {
    var resultPost = await GetPostByIdAsync(postId);
    if (resultPost == null) return false;

    _context.Posts.Remove(resultPost);
    _context.SaveChanges();

    return true;
  }
}
