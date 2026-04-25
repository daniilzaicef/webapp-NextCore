using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    //Портфолио
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название проекта")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Введите использованные технологии")]
        public string Technologies { get; set; } 
        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
