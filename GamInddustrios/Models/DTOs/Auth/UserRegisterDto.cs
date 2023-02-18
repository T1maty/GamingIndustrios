using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models.DTOs.Auth
{
    public class UserRegisterDto
    {
        [MaxLength(60)]
        public string GmailAddress { get; set; }
        [MaxLength(20)]
        public string Username { get;set;} = string.Empty;
        [MaxLength(16)]
        public string Password { get;set;} = string.Empty;
    }
}
