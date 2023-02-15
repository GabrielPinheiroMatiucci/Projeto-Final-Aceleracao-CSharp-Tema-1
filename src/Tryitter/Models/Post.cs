using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models
{

  public class Post
  {
    [Key]
    public int PostId { get; set; }

    // public int UserId { get; set; } -> lembrar de trocar o nome no controller

    [Required]
    [StringLength(300)]
    public string Text { get; set; } = null!;

    public DateTime Date { get; set; }
    public string Imagem { get; set; } = null!;

    [ForeignKey("Id")]
    public int Id { get; set; }

    public Student Student { get; set; } = null!;
  }
}