using Application.Common.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly GymDbContext _context;

        public SubscriptionRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task<Subscription> AddSubscriptionAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<bool> DeleteSubscriptionAsync(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
                return false;

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return true;
        }
        

        public async Task<List<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription?> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }

        public async Task<Subscription?> UpdateSubscriptionAsync(Subscription subscription)
        {
            var existingSubscription = await _context.Subscriptions.FindAsync(subscription.Id);

            if (existingSubscription == null)
                return null;

            existingSubscription.MemberId = subscription.MemberId;
            existingSubscription.MembershipPlanId = subscription.MembershipPlanId;
            existingSubscription.StartDate = subscription.StartDate;
            existingSubscription.EndDate = subscription.EndDate;
            existingSubscription.Status = subscription.Status;

            await _context.SaveChangesAsync();

            return existingSubscription;
        }
    }
    
}
