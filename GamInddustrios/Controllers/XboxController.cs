using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XboxController : ControllerBase
    {
        private readonly IXboxServices _xboxServices;
        public XboxController(IXboxServices xboxServices)
        {
            _xboxServices = xboxServices;
        }
        [HttpPost]
        public Xbox AddXbox(Xbox xbox)
        {
            return _xboxServices.AddXbox(xbox);
        }
    }
}
