using Domain.Entities;

namespace Application.Common.Interface.Services
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser user);
    }
}