using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models
{
    public class AdminPanel
    {
        [MaxLength(40)]
        public string GmailAddress { get; set; }
        [MaxLength(18)]
        public string Password { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
