using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models
{

  public class Post
  {
    // public Post(string text)
    // {
    //   Text = text;
    // }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(300)]
    public string Text { get; set; } = null!;

    public DateTime Date { get; set; }
    public string Imagem { get; set; } = null!;
  }
}