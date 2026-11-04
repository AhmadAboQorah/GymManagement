namespace Application.Common.Interface.Services
{
    public interface ICurrentUserService
    {
        int UserId { get; }

        string UserName { get; }

        string Email { get; }

        string Role { get; }

        bool IsAuthenticated { get; }
    }
}