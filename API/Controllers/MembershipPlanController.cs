using Application.Common.Interface.Services;
using Application.DTOs.MembershipPlan;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipPlanController : ControllerBase
    {
        private readonly IMembershipPlanService _planService;


        public MembershipPlanController(
            IMembershipPlanService planService)
        {
            _planService = planService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var plans =
                await _planService.GetAllPlansAsync();

            return Ok(plans);
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plan =
                await _planService.GetPlanByIdAsync(id);


            if (plan == null)
                return NotFound();


            return Ok(plan);
        }




        [HttpPost]
        public async Task<IActionResult> Create(
            CreateMembershipPlanDto dto)
        {
            var id =
                await _planService.AddPlanAsync(dto);


            return Ok(new
            {
                Message = "Membership plan created successfully",
                Id = id
            });
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateMembershipPlanDto dto)
        {

            var result =
                await _planService.UpdatePlanAsync(id, dto);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Membership plan updated successfully"
            });
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result =
                await _planService.DeletePlanAsync(id);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Membership plan deleted successfully"
            });
        }
    }
}