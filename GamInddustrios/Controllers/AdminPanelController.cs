using GamingIndustrios.Models;
using GamingIndustrios.Models.DTOs.AdminPanel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Cryptography;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {
        public static AdminPanel adminPanel = new AdminPanel();
        private readonly IConfiguration _configuration;

        public AdminPanelController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [Authorize]
        [HttpPost("registerAdmin")]
        public async Task <ActionResult<AdminPanel>> RegisterAdmin(AdminPanelDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash);
            adminPanel.GmailAddress = request.GmailAddress;
            adminPanel.PasswordHash = passwordHash;
            adminPanel.PhoneNumber = request.PhoneNumber;

            return Ok(adminPanel);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
