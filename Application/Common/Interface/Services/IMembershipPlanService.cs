using Application.DTOs.MembershipPlan;

namespace Application.Common.Interface.Services
{
    public interface IMembershipPlanService
    {
        Task<List<MembershipPlanDto>> GetAllPlansAsync();

        Task<MembershipPlanDto?> GetPlanByIdAsync(int id);

        Task<int> AddPlanAsync(CreateMembershipPlanDto dto);

        Task<bool> UpdatePlanAsync(int id, UpdateMembershipPlanDto dto);

        Task<bool> DeletePlanAsync(int id);
    }
}