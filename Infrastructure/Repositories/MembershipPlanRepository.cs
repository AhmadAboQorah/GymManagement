using Application.Common.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MembershipPlanRepository : IMembershipPlanRepository
    {
       
        private readonly GymDbContext _context;

        public MembershipPlanRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<MembershipPlan> AddPlanAsync(MembershipPlan plan)
        {
            _context.MembershipPlans.Add(plan);
            await _context.SaveChangesAsync();
            return plan;
        }

        public async Task<bool> DeletePlanAsync(int id)
        {
            var plan = await _context.MembershipPlans.FindAsync(id);
            if (plan == null)
                return false;

            _context.MembershipPlans.Remove(plan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MembershipPlan>> GetAllPlansAsync()
        {
            return await _context.MembershipPlans.ToListAsync();
        }

        public async Task<MembershipPlan?> GetPlanByIdAsync(int id)
        {
            return await _context.MembershipPlans.FindAsync(id);
        }

        public async Task<MembershipPlan?> UpdatePlanAsync(MembershipPlan plan)
        {
            var existingPlan = await _context.MembershipPlans.FindAsync(plan.Id);

            if (existingPlan == null)
                return null;

            existingPlan.PlanName = plan.PlanName;
            existingPlan.Price = plan.Price;
            existingPlan.DurationInMonths = plan.DurationInMonths;

            await _context.SaveChangesAsync();

            return existingPlan;
        }
    }
   
}
