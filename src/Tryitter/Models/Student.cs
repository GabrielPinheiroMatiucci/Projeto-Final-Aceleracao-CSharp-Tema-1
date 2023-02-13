using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models;

public class Student
{
  public Student(string name, string email, string module, string password)
  {
    Name = name;
    Email = email;
    Module = module;
    Password = password;
  }

  [Key]
  public int Id { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  public string Email { get; set; }

  [Required]
  public string Module { get; set; }

  [Required]
  public string Password { get; set; }
}
