using Application.Common.Interface.Repositories;
using Application.Common.Interface.Services;
using Application.DTOs.Subscription;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;


        public SubscriptionService(
            ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }



        public async Task<List<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            var subscriptions =
                await _subscriptionRepository.GetAllSubscriptionsAsync();


            return subscriptions.Select(s => new SubscriptionDto
            {
                Id = s.Id,
                MemberId = s.MemberId,
                MembershipPlanId = s.MembershipPlanId,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                Status = s.Status

            }).ToList();
        }




        public async Task<SubscriptionDto?> GetSubscriptionByIdAsync(int id)
        {
            var subscription =
                await _subscriptionRepository.GetSubscriptionByIdAsync(id);


            if (subscription == null)
                return null;


            return new SubscriptionDto
            {
                Id = subscription.Id,
                MemberId = subscription.MemberId,
                MembershipPlanId = subscription.MembershipPlanId,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                Status = subscription.Status
            };
        }




        public async Task<int> AddSubscriptionAsync(
            CreateSubscriptionDto dto)
        {

            var subscription = new Subscription
            {
                MemberId = dto.MemberId,
                MembershipPlanId = dto.MembershipPlanId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = dto.Status
            };


            var result =
                await _subscriptionRepository
                .AddSubscriptionAsync(subscription);


            return result.Id;
        }





        public async Task<bool> UpdateSubscriptionAsync(
            int id,
            UpdateSubscriptionDto dto)
        {

            var subscription =
                await _subscriptionRepository
                .GetSubscriptionByIdAsync(id);


            if (subscription == null)
                return false;



            subscription.MemberId = dto.MemberId;
            subscription.MembershipPlanId = dto.MembershipPlanId;
            subscription.StartDate = dto.StartDate;
            subscription.EndDate = dto.EndDate;
            subscription.Status = dto.Status;



            var result =
                await _subscriptionRepository
                .UpdateSubscriptionAsync(subscription);


            return result != null;
        }





        public async Task<bool> DeleteSubscriptionAsync(int id)
        {
            return await _subscriptionRepository
                .DeleteSubscriptionAsync(id);
        }
    }
}