using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    //Портфолио/Кейсы
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название проекта")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
        public string Technologies { get; set; } // Используемые технологии (C#, .NET, SQL Server и т.д.)

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
