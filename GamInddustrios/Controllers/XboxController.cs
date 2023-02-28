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

        private readonly IXboxServices _xboxServices;
        public XboxController(IXboxServices xboxServices)
        {
            _xboxServices = xboxServices;

        }
        /// <summary>
        /// Create Xbox Request
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Xbox
        ///   {
        ///         "id": 0,
        ///         "name": "Xbox Series X All-Edition",
        ///         "price": 659 baksov,
        ///       }
        /// </remarks>
        /// <param name="xbox"></param>
        /// <returns>A create request Xbox</returns>
        [HttpPost]
        public Xbox AddXbox(Xbox xbox)
        {
            return _xboxServices.AddXbox(xbox);
        }
    }
}
