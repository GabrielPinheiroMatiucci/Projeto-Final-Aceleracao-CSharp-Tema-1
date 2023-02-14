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

<<<<<<< HEAD:src/Tryitter/Repository/TryitterRepository.cs
  public List<Post>? GetPosts()
  {
    return _context.Posts.ToList();
=======
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
>>>>>>> 960690294dff8dc45c4410729d1dc9fea622c039:Tryitter/Repository/TryitterRepository.cs
  }
}
