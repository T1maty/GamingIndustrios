using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Create Customer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Customer
        ///   {
        ///       "id": 0, 
        ///       "firstName": "string",
        ///       "lastName": "string",
        ///       "phoneNumber": 0,
        ///       "separation": "string",
        ///       "brunchNumber": 0,
        ///       "createdDate": "2023-02-28T19:18:52.469Z"
        ///   }
    /// </remarks>
    /// <param name="customer"></param>
    /// <returns>A new Customer</returns>

    [HttpPost]
        public  Customer AddCustomer(Customer customer)
        {
            return _customerService.AddCustomer(customer);
        }
    }
}
