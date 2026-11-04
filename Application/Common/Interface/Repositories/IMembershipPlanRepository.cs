using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interface.Repositories
{
    public interface IMembershipPlanRepository
    {
        Task<List<MembershipPlan>> GetAllPlansAsync();

        Task<MembershipPlan?> GetPlanByIdAsync (int id);

        Task<MembershipPlan> AddPlanAsync(MembershipPlan plan);

        Task<bool> DeletePlanAsync(int id);

        Task<MembershipPlan?> UpdatePlanAsync(MembershipPlan plan);
    }
}
