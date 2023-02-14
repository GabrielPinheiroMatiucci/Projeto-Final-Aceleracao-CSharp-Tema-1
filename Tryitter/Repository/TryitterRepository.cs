using Tryitter.Models;

namespace Tryitter.Repository;

public class TryitterRepository
{
  private readonly TryitterContext _context;

  public TryitterRepository(TryitterContext context)
  {
    _context = context;
  }

  public virtual List<Student>? GetStudents()
  {
    return _context.Students.ToList();
  }

  public virtual Student? GetStudent(int id)
  {
    return _context.Students.FirstOrDefault(student => student.Id == id);
  }

  public virtual int CreateStudent(Student student)
  {
    _context.Students.Add(student);
    _context.SaveChanges();

    return student.Id;
  }

  public virtual bool UpdateStudent(int id, Student student)
  {
    if (!_context.Students.Any(std => std.Id == id) || id != student.Id)
      return false;

    _context.Students.Update(student);
    _context.SaveChanges();

    return true;
  }

  public virtual bool DeleteStudent(int id)
  {
    Student? student = GetStudent(id);

    if (student == null)
      return false;

    _context.Students.Remove(student);
    _context.SaveChanges();

    return true;
  }
}
