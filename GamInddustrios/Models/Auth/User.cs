using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models.Auth
{
    public class User : BaseObject
    {
        [Required(ErrorMessage = "Please enter Username")]
        [MaxLength(10)]
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

    }
}
