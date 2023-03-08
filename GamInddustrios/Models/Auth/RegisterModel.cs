using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string? Username { get; set; }
    }
}
