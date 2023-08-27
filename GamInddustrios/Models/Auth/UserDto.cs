using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models.Auth
{
    public class UserDto : BaseObject
    {
        [MaxLength(20)]
        public string? Gmail { get; set; } 
        [MaxLength(15)]
        public string? Username { get; set; } 
        [MaxLength(18)]
        public string? Password { get; set; } 
         
    }
}
