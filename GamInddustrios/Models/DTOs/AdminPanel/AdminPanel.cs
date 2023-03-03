using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models.DTOs.AdminPanel
{
    public class AdminPanel : BaseObject
    {
        [MaxLength(40)]
        public string GmailAddress { get; set; } = string.Empty;
        [MaxLength(18)]
        public string Password { get; set; } = string.Empty;
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; } 
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
