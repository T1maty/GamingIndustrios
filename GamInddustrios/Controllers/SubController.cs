using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISubscriptionService _subservice;
        public SubController(ISubscriptionService subscriptionService, IMediator mediator)
        {
            _subservice = subscriptionService;
            _mediator = mediator;
        }
        [HttpPost]
        public  Subscription AddSubscription(Subscription subscription)
        {
            return _subservice.AddSubscription(subscription);
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
            var result = _subservice.DeleteSubscription(id);
            return StatusCode((int)result.StatusCode, result);
        }

    }
}
