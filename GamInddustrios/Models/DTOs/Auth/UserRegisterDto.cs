namespace GamingIndustrios.Models.DTOs.Auth
{
    public class UserRegisterDto
    {
        public string GmailAddress { get; set; }
        public string Username { get;set;} = string.Empty;
        public string Password { get;set;} = string.Empty;
    }
}
