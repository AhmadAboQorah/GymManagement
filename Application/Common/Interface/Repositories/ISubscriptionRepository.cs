using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Common.Interface.Repositories
{
    public interface ISubscriptionRepository
    {
        Task <Subscription?> GetSubscriptionByIdAsync(int id);

        Task<List<Subscription>> GetAllSubscriptionsAsync();

        Task<Subscription> AddSubscriptionAsync(Subscription subscription);

        Task<bool> DeleteSubscriptionAsync(int id);

        Task<Subscription?> UpdateSubscriptionAsync(Subscription subscription);
    }
}
