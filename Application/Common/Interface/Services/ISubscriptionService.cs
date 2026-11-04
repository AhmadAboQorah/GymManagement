using Application.DTOs.Subscription;

namespace Application.Common.Interface.Services
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionDto>> GetAllSubscriptionsAsync();

        Task<SubscriptionDto?> GetSubscriptionByIdAsync(int id);

        Task<int> AddSubscriptionAsync(CreateSubscriptionDto dto);

        Task<bool> UpdateSubscriptionAsync(int id, UpdateSubscriptionDto dto);

        Task<bool> DeleteSubscriptionAsync(int id);
    }
}