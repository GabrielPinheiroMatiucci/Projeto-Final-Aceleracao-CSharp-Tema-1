using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models;

public class Post
{
  public Post(string text)
  {
    Text = text;
  }

  [Key]
  public int Id { get; set; }

  [Required]
  public string Text { get; set; }
}