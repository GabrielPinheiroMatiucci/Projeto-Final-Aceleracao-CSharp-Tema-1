using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models
{

  public class Post
  {
    public Post(string text, string image, string date)
    {
      Text = text;
      Imagem = image;
      Date = date;
    }

    [Key]
    public int PostId { get; set; }

    [ForeignKey("Id")] /* Id do studant */
    public int Id { get; set; }

    [Required]
    [StringLength(300)]
    public string Text { get; set; } = null!;

    public string Date { get; set; } = DateTime.Now.ToString();
    public string Imagem { get; set; } = null!;
  }
}