using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.ViewModel
{
    public class VacancyResponseViewModel
    {
        [Required(ErrorMessage = "Введите ФИО")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введите Email"), 
            EmailAddress(ErrorMessage = "Введите корректный email адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        public string Message { get; set; }

        public string VacancyTitle { get; set; }
    }
}
