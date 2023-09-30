using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models.Auth
{
    public class UserDto : BaseObject
    {
        [Required(ErrorMessage = "Please enter Your Gmail")]
        [MaxLength(20)]
        [EmailAddress]
        public string? Gmail { get; set; }
        [Required(ErrorMessage = "Please enter Your Username")]
        [MaxLength(15)]
        
        public string? Username { get; set; }
        [Required(ErrorMessage = "Please enter Your Password")]

        [MaxLength(18)]
        
        public string? Password { get; set; } 
         
    }
}
