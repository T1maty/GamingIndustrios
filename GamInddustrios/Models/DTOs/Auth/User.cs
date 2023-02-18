using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models.DTOs.Auth
{
    public class User : BaseObject
    {
        [MaxLength(60)]
        public string? GmailAddress { get; set; }
        [MaxLength(20)]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; }= string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
