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

  public void CreateStudent(Student student)
  {
    _context.Students.Add(student);
    _context.SaveChanges();
  }
}
