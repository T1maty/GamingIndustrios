using AutoMapper;
using GamingIndustrios.Models;
using GamingIndustrios.Models.DTOs.Incoming;
using GamingIndustrios.Models.DTOs.Outgoing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private static List<Driver> drivers = new List<Driver>();
        private readonly ILogger<DriversController> _logger;
        private readonly IMapper _mapper;
        public DriversController(ILogger<DriversController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDrivers()
        {
            var items = drivers.Where(x => x.Status == 1).ToList();

            var driverList = _mapper.Map<IEnumerable<DriverDto>>(items);
            return Ok(driverList);
        }
        /// <summary>
        /// Create Driver
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Computer
        ///   {
        ///      "id": 0,
        ///       "FirstName": "Apolo",
        ///        "LastName": "Asus",
        ///        "DriverNumber": "44",
        ///        "worldChampionships": "string"
        ///       }
        /// </remarks>
        /// <param name="driver"></param>
        /// <returns>A create driver</returns>
        [HttpPost]
        public IActionResult CreateDriver(DriverCreationDto data)
        {
            var _driver = _mapper.Map<Driver>(data);

            if (ModelState.IsValid)
            {
                drivers.Add(_driver);

                return CreatedAtAction("GetDriver", new { _driver.Id }, data);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [HttpGet("{id}")]
        public IActionResult GetDriver(Guid id)
        {
            var item = drivers.FirstOrDefault(  x=> x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDriver(Guid id, Driver item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            var existItem = drivers.FirstOrDefault(x => x.Id == id);
            if (existItem == null)
            {
                return NotFound();
            }
            existItem.FirstName = item.FirstName;
            existItem.LastName = item.LastName;
            existItem.DriverNumber = item.DriverNumber;
            existItem.WorldChampionships = item.WorldChampionships;


            return NoContent();
        }
        

    }
}
