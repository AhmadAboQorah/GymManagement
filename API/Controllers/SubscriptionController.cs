using Application.Common.Interface.Services;
using Application.DTOs.Subscription;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;


        public SubscriptionController(
            ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscriptions =
                await _subscriptionService.GetAllSubscriptionsAsync();

            return Ok(subscriptions);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscription =
                await _subscriptionService.GetSubscriptionByIdAsync(id);


            if (subscription == null)
                return NotFound();


            return Ok(subscription);
        }




        [HttpPost]
        public async Task<IActionResult> Create(
            CreateSubscriptionDto dto)
        {
            var id =
                await _subscriptionService.AddSubscriptionAsync(dto);


            return Ok(new
            {
                Message = "Subscription created successfully",
                Id = id
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateSubscriptionDto dto)
        {

            var result =
                await _subscriptionService.UpdateSubscriptionAsync(id, dto);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Subscription updated successfully"
            });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result =
                await _subscriptionService.DeleteSubscriptionAsync(id);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Subscription deleted successfully"
            });
        }
    }
}