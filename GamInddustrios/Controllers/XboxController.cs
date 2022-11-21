using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class XboxController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly IXboxServices _xboxServices;
        public XboxController(IXboxServices xboxServices, IDistributedCache cache)
        {
            _xboxServices = xboxServices;
            _cache = cache;
        }
        [HttpPost]
        public Xbox AddXbox(Xbox xbox)
        {
            return _xboxServices.AddXbox(xbox);
        }
    }
}
