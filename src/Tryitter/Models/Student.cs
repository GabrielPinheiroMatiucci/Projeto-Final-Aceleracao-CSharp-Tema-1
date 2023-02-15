using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models;

public class Student : Credentials
{
  public Student(
    string name, string email, string module, string password
  ) : base(email, password)
  {
    Name = name;
    Module = module;
  }

  [Key]
  public int Id { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  public string Module { get; set; }

  public IEnumerable<Post>? Posts { get; set; }
}
