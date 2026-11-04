using Application.Common.Interface.Repositories;
using Application.Common.Interface.Services;
using Application.DTOs.Auth;
using Domain.Entities;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService(
            IApplicationUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
        {

            var user = await _userRepository.LoginAsync(
                dto.UserName,
                dto.Password);

            if (user == null || !user.IsActive)
                return null;

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                ExpiresAt = DateTime.UtcNow.AddHours(2)
            };
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var exists = await _userRepository.CheckEmailExistsAsync(dto.Email);

            if (exists)
                return false;

            var user = new ApplicationUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                PhoneNumber = dto.PhoneNumber,
                Role = dto.Role,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);

            return true;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
        {
            return await _userRepository.ChangePasswordAsync(
                dto.UserName,
                dto.OldPassword,
                dto.NewPassword);
        }

        public async Task<bool> ActivateUserAsync(int userId)
        {
            var user = await _userRepository.ActivateUserAsync(userId);

            return user != null;
        }
    }
}