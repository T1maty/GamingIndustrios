using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGamesService _gameservice;
        public GameController(IGamesService gamesService)
        {
            _gameservice = gamesService;
        }
        /// <summary>
        /// Create Game
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Games
        ///   {
        ///         "id": 0,
        ///         "name": "Call of duty MW 2 2022",
        ///         "price": 50,
        ///         "genre": "AAA, Shooter",
        ///       }
        /// </remarks>
        /// <param name="games"></param>
        /// <returns>A create games</returns>
        [HttpPost]
        public Game AddGames(Game games)
        {
            return _gameservice.AddGames(games);
        }

        /// <summary>
        /// Deletes user by specified id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Result of deletion</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int? id)
        {
            var result = _gameservice.DeleteGames(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
