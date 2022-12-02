using GamingIndustrios.Models;
using GamingIndustrios.Models.DTOs.Incoming;
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
        public DriversController(ILogger<DriversController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetDrivers()
        {
            var items = drivers.Where(x => x.Status ==1 ).ToList();
            return Ok(items);
        }
        [HttpPost]
        public IActionResult CreateDriver(Driver data)
        {
            if (ModelState.IsValid)
            {
                drivers.Add(data);
                return CreatedAtAction("GetDriver", new { data.Id }, data);
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
        [HttpPost]
        public IActionResult CreateDriver(DriverCreationDto data)
        {
            var _driver = new Driver()
            {
                Id = Guid.NewGuid(),
                Status = 1,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now,
                DriverNumber = data.DriverNumber,
                FirstName = data.FirstName,
                LastName = data.LastName,
                WorldChampionships = data.WorldChampionships
            };
            if (ModelState.IsValid)
            {
                drivers.Add(_driver);

                return CreatedAtAction("GetDriver", new { _driver.Id }, data);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
    }
}
