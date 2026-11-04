using Domain.Entities;

namespace Application.Common.Interface.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser?> GetUserByIdAsync(
            int userId);

        Task<ApplicationUser?> GetUserByNameAsync(
            string userName);

        Task<ApplicationUser?> GetUserByEmailAsync(
            string email);

        Task<List<ApplicationUser>> GetAllUsersAsync();

        Task<bool> CheckEmailExistsAsync(
            string email);

        Task<bool> ChangePasswordAsync(
            string userName,
            string oldPassword,
            string newPassword);

        Task<ApplicationUser?> ActivateUserAsync(
            int userId);

        Task AddAsync(
            ApplicationUser user);

        Task<ApplicationUser?> LoginAsync(
            string userName,
            string password);
    }
}