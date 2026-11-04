using Application.Common.Interface.Services;
using Application.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);


            if (result == null)
            {
                return StatusCode(401, new
                {
                    Message = "Invalid username or password"
                });
            }


            return Ok(new
            {
                Message = "Login successful",
                Data = result
            });
        }




        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);


            if (!result)
            {
                return BadRequest(new
                {
                    Message = "Registration failed"
                });
            }


            return Ok(new
            {
                Message = "User registered successfully"
            });
        }




        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            var result = await _authService.ChangePasswordAsync(dto);


            if (!result)
            {
                return BadRequest(new
                {
                    Message = "Password change failed"
                });
            }


            return Ok(new
            {
                Message = "Password changed successfully"
            });
        }




        [HttpPut("ActivateUser/{id}")]
        public async Task<IActionResult> ActivateUser(int id)
        {
            var result = await _authService.ActivateUserAsync(id);


            if (!result)
            {
                return NotFound(new
                {
                    Message = "User not found"
                });
            }


            return Ok(new
            {
                Message = "User activated successfully"
            });
        }

    }
}