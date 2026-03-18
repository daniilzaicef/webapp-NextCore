using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    public class FeedbackMessage
    {
        //Заявки/Контакты
        public int Id { get; set; }

        [Required(ErrorMessage ="Введите ФИО")]
        [StringLength(100)]
        public string SenderName { get; set; }

        [Required(ErrorMessage ="Введите Email")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        public string Message { get; set; }

        public DateTime ReceivedDate { get; set; }

        public string RelatedVacancy { get; set; } // Если это отклик на вакансию

    }
}
