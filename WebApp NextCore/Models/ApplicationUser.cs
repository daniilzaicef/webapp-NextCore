using Microsoft.AspNetCore.Identity;

namespace WebApp_NextCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? AvatarPath { get; set; }
        public string? About { get; set; }
    }
}
