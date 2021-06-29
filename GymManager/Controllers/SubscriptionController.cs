using GymManager.Core.DTOs;
using GymManager.Core.DTOs.Subscriptions;
using GymManager.Core.Services.SubscriptionService;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("getAll")]
        public IActionResult GetSubscriptions()
        {
            var subscriptions = _subscriptionService.GetSubscriptions();

            if (subscriptions == null)
            {
                return NotFound();
            }

            return Ok(subscriptions);
        }

        [HttpGet("validateUserSubscription")]
        public IActionResult ValidateUserSubscription(int userId)
        {
            var subscription = _subscriptionService.GetUserSubscription(userId);

            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        [HttpPost("addSubscription")]
        public IActionResult AddSubscription(SubscriptionDto subscription)
        {
            var addedSubscription = _subscriptionService.AddSubscription(subscription);

            if (addedSubscription == null)
            {
                return NotFound();
            }

            return Ok(addedSubscription);
        }

        [HttpPut("updateSubscription")]
        public IActionResult UpdateSubscription(SubscriptionDto subscription)
        {
            var updatedSubscription = _subscriptionService.UpdateSubscription(subscription);

            if (updatedSubscription == null)
            {
                return NotFound();
            }

            return Ok(updatedSubscription);
        }

        [HttpDelete("removeSubscription")]
        public IActionResult RemoveSubscription(int subscriptionId)
        {
            var removedSubscription = _subscriptionService.RemoveSubscription(subscriptionId);

            if (removedSubscription == null)
            {
                return NotFound();
            }

            return Ok(removedSubscription);
        }
    }
}
