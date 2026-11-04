using System.Security.Claims;
using Application.Common.Interface.Services;
using Application.DTOs.Member;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _memberService.GetAllMembersAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);

            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMemberDto dto)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdClaim, out var userId))
                return Unauthorized(new { Message = "Invalid or missing user id in token" });

            var id = await _memberService.AddAsync(userId, dto);

            return Ok(new
            {
                Message = "Member created successfully",
                Id = id
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMemberDto dto)
        {
            var result = await _memberService.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return Ok(new
            {
                Message = "Member updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _memberService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok(new
            {
                Message = "Member deleted successfully"
            });
        }

        [HttpGet("{id}/reservations")]
        public async Task<IActionResult> GetReservations(int id)
        {
            var reservations = await _memberService.GetMemberReservationsAsync(id);
            return Ok(reservations);
        }

        [HttpGet("{id}/subscriptions")]
        public async Task<IActionResult> GetSubscriptions(int id)
        {
            var subscriptions = await _memberService.GetMemberSubscriptionsAsync(id);
            return Ok(subscriptions);
        }
    }
}