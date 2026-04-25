using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Введите назване")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Введите краткое описание")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage ="Введите содержание")]
        public string Content {  get; set; }

        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
