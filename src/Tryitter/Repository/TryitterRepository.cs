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
  public List<Post>? GetPosts(int id)
  {
    var result = _context.Posts.Where(post => post.Id == id);
    return result.ToList();
  }

  public Post? GetLastPost(int id)
  {
    var result = _context.Posts.Where(post => post.Id == id);
    return result.ToList().Last();
  }

  public int CreatePost(int id, Post post)
  {
    var student = GetStudent(id);

    // checando se o student
    if (student == null) throw new InvalidOperationException();

    _context.Posts.Add(post);
    _context.SaveChanges();

    // n sei se precisa retornar esse id?
    return post.PostId;
  }

  public bool UpdatePost(int id, Post post)
  {
    // poderia fazer uma funçãos p realizar essa checagem ?
    var student = GetStudent(id);
    if (student == null) throw new InvalidOperationException();

    var resultPost = _context.Posts.Where(contextPost => contextPost.PostId == post.PostId).FirstOrDefault();

    _context.Posts.Update(post);
    // será que preciso colocar cada integrante do POst? Tipo Text, Image, ...
    // i.e.: resultPost.Text = post.Text;

    _context.SaveChanges();

    return true;
  }

  public bool DeletePost(int id, int postId)
  {
    // poderia fazer uma funçãos p realizar essa checagem ?
    var student = GetStudent(id);
    if (student == null) throw new InvalidOperationException();

    var post = _context.Posts.Where(post => post.PostId == postId).First();

    _context.Posts.Remove(post);
    _context.SaveChanges();

    return true;
  }
}
