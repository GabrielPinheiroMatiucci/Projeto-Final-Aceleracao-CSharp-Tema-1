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

    [Required(ErrorMessage = "É necessário o id do student para conseguir postar algo.")]
    [ForeignKey("Id")] /* Id do studant */
    public int Id { get; set; }

    [Required]
    [StringLength(300, ErrorMessage = "O texto do post só pode conter até 300 caracteres.")] /*  */
    public string Text { get; set; } = null!;

    public string Date { get; set; } = DateTime.Now.ToString();
    public string Imagem { get; set; } = null!;
  }
}