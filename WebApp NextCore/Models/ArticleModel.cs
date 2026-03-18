using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    //Блог/Новости
    public class ArticleModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Announce { get; set; } // Анонс статьи для списка
        public string Content { get; set; } // Полный текст статьи 

        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; } // Изображение превью статьи
    }
}
