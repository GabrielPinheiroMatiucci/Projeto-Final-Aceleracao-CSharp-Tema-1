using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models;

public class Credentials
{
  public Credentials(string email, string password)
  {
    Email = email;
    Password = password;
  }

  [Required]
  public string Email { get; set; }

  [Required]
  public string Password { get; set; }
}
