using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApp_NextCore.Models;
using Microsoft.AspNetCore.Identity;
namespace WebApp_NextCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-C77HFRQ;Database=NexusCore;Trusted_Connection=True;TrustServerCertificate=True;")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }



        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<VacancyModel> Vacancy { get; set; }
        public DbSet<FeedbackMessage> FeedbacksMessage { get; set; }
        public DbSet<VacancyResponse> VacancyResponses { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; } 
        public DbSet<ServiceRequest> ServiceRequests { get; set; }


    }
}
