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

        [Required(ErrorMessage ="Введите номер телефона")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Номер должен состоять ровно из 12 цифр")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Допускаются только цифры")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        public string Message { get; set; }

        public DateTime ReceivedDate { get; set; } = DateTime.Now;

    }
}
