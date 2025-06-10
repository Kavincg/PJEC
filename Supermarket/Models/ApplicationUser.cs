using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Supermarket.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string StreetAdress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

    }
}
