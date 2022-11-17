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
