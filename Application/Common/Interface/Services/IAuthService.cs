using Application.DTOs.Auth;

namespace Application.Common.Interface.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginDto dto);

        Task<bool> RegisterAsync(RegisterDto dto);

        Task<bool> ChangePasswordAsync(ChangePasswordDto dto);

        Task<bool> ActivateUserAsync(int userId);
    }
}