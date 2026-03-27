using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_NextCore.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Некорректный Email")]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        // Связь с услугой
        public int ServiceId { get; set; }
        public ServiceModel? Service { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
