namespace GamingIndustrios.Models.DTOs.Auth
{
    public class User : BaseObject
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
