using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaystationController : ControllerBase
    {
        private readonly IPlaystationService _playstationService;

        public PlaystationController(IPlaystationService playstationService)
        {
            _playstationService = playstationService;
        }

        /// <summary>
        /// Create Playstation
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Playstation
        ///   {
        ///         "id": 0,
        ///         "name": "Playstation 5 Digital edition",
        ///         "price": 750 baksov,
        ///       }
        /// </remarks>
        /// <param name="playstation"></param>
        /// <returns>A create request Playstation</returns>
        [HttpPost]
        public  Playstation AddPlaystation(Playstation playstation)
        {
            return _playstationService.AddPlaystation(playstation);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePlaystationPatch([FromBody] JsonPatchDocument product, [FromRoute] int id)
        {
            await _playstationService.UpdatePlaystationPatchAsync(id, product);
            return Ok(product);
        }
    }
}
