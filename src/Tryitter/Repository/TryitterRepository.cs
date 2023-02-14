using Tryitter.Models;

namespace Tryitter.Repository;

public class TryitterRepository
{
  private readonly TryitterContext _context;

  public TryitterRepository(TryitterContext context)
  {
    _context = context;
  }

  public List<Student>? GetStudents()
  {
    return _context.Students.ToList();
  }

  public Student? GetStudent(int id)
  {
    return _context.Students.FirstOrDefault(student => student.Id == id);
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

  public bool DeleteStudent(int id)
  {
    Student? student = GetStudent(id);

    if (student == null)
      return false;

    _context.Students.Remove(student);
    _context.SaveChanges();

    return true;
  }

  // CRUD Post
  public List<Post>? GetPosts()
  {
    return _context.Posts.ToList();
  }

  public Post? GetLastPost()
  {
    return _context.Posts.ToList().Last();
  }

  public int CreatePost(Post post)
  {
    _context.Posts.Add(post);
    _context.SaveChanges();

    return post.PostId;
  }

  public bool UpdatePost(int id, Post post)
  {
    if (!_context.Students.Any(std => std.Id == id) || id != student.Id)
      return false;

    _context.Students.Update(student);
    _context.SaveChanges();

    return true;
  }

  // public bool DeletePost(int id)
  // {
  //   Student? student = GetStudent(id);

  //   if (student == null)
  //     return false;

  //   _context.Students.Remove(student);
  //   _context.SaveChanges();

  //   return true;
  // }
}
