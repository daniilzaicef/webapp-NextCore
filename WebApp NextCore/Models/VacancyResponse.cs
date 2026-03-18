using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    public class VacancyResponse
    {
        public int id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message {  get; set; }

        public string VacancyTitle { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
