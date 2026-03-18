using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.ViewModel
{
    public class VacancyResponseViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public string VacancyTitle { get; set; }
    }
}
