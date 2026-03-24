using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string? FullDescription { get; set; }


    }
}
