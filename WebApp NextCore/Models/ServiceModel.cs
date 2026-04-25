using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Введите название")]
        [StringLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage ="Введите описание")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Введите полное описание")]
        public string? FullDescription { get; set; }
        public string? IamgePath { get; set; }

    }
}
