using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models.DTOs.AdminPanel
{
    public class AdminPanelDto
    {
        [MaxLength(40)]
        public string GmailAddress { get; set; } = string.Empty;
        [MaxLength(18)]
        public string Password { get; set; } = string.Empty;
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
