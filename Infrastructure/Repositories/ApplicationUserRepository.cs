using Application.Common.Interface.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly GymDbContext _context;

        public ApplicationUserRepository(GymDbContext context)
        {
            _context = context;
        }


        public async Task<ApplicationUser?> LoginAsync(
            string userName,
            string password)
        {
            // Find user by FullName or Email
            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(u =>
                    (u.FullName == userName || u.Email == userName)
                    && u.IsActive);

            // Check if user exists
            if (user == null)
                return null;

            // Verify password using BCrypt
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                password,
                user.PasswordHash
            );

            if (!isPasswordValid)
                return null;

            return user;
        }


        public async Task<ApplicationUser?> GetUserByIdAsync(int userId)
        {
            return await _context.ApplicationUsers
                .FindAsync(userId);
        }

        public async Task<ApplicationUser?> GetUserByNameAsync(string userName)
        {
            return await _context.ApplicationUsers
                .FirstOrDefaultAsync(u => u.FullName == userName);
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return await _context.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _context.ApplicationUsers
                .ToListAsync();
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _context.ApplicationUsers
                .AnyAsync(u => u.Email == email);
        }


        public async Task<bool> ChangePasswordAsync(
            string userName,
            string oldPassword,
            string newPassword)
        {
            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(u =>
                    (u.FullName == userName || u.Email == userName)
                    && u.IsActive);

            if (user == null)
                return false;

            // Verify old password
            bool isValid = BCrypt.Net.BCrypt.Verify(
                oldPassword,
                user.PasswordHash
            );

            if (!isValid)
                return false;

            // Hash new password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<ApplicationUser?> ActivateUserAsync(int userId)
        {
            var user = await _context.ApplicationUsers
                .FindAsync(userId);

            if (user == null)
                return null;

            user.IsActive = true;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task AddAsync(ApplicationUser user)
        {
            await _context.ApplicationUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}