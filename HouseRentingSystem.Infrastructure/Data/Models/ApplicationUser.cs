using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static HouseRentingSystem.Infrastructure.Constants.ValidationConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; } = null!;
    }
}
