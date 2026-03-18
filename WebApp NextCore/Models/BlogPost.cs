namespace WebApp_NextCore.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content {  get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
