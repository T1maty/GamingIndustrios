using AutoMapper;
using GamingIndustrios.Models;
using GamingIndustrios.Models.DTOs.Outgoing;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;
        private static List<Computer> computers = new List<Computer>();
        private readonly IMapper _mapper;
        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }
        [HttpPost]
        public Computer AddComputer(Computer computer)
        {
            return _computerService.AddComputer(computer);
        }
       

        /// <summary>
        /// Deletes user by specified id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Result of deletion</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteComputer(int id)
        {
            var result = _computerService.DeleteComputer(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
