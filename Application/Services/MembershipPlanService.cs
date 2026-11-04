using Application.Common.Interface.Repositories;
using Application.Common.Interface.Services;
using Application.DTOs.MembershipPlan;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class MembershipPlanService : IMembershipPlanService
    {
        private readonly IMembershipPlanRepository _planRepository;


        public MembershipPlanService(
            IMembershipPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }



        public async Task<List<MembershipPlanDto>> GetAllPlansAsync()
        {
            var plans =
                await _planRepository.GetAllPlansAsync();


            return plans.Select(p => new MembershipPlanDto
            {
                Id = p.Id,
                PlanName = p.PlanName,
                Price = p.Price,
                DurationInMonths = p.DurationInMonths

            }).ToList();
        }




        public async Task<MembershipPlanDto?> GetPlanByIdAsync(int id)
        {
            var plan =
                await _planRepository.GetPlanByIdAsync(id);


            if (plan == null)
                return null;



            return new MembershipPlanDto
            {
                Id = plan.Id,
                PlanName = plan.PlanName,
                Price = plan.Price,
                DurationInMonths = plan.DurationInMonths
            };
        }





        public async Task<int> AddPlanAsync(
            CreateMembershipPlanDto dto)
        {

            var plan = new MembershipPlan
            {
                PlanName = dto.PlanName,
                Price = dto.Price,
                DurationInMonths = dto.DurationInMonths
            };


            var result =
                await _planRepository.AddPlanAsync(plan);


            return result.Id;
        }





        public async Task<bool> UpdatePlanAsync(
            int id,
            UpdateMembershipPlanDto dto)
        {

            var plan =
                await _planRepository.GetPlanByIdAsync(id);


            if (plan == null)
                return false;



            plan.PlanName = dto.PlanName;
            plan.Price = dto.Price;
            plan.DurationInMonths = dto.DurationInMonths;



            var result =
                await _planRepository.UpdatePlanAsync(plan);


            return result != null;
        }





        public async Task<bool> DeletePlanAsync(int id)
        {
            return await _planRepository.DeletePlanAsync(id);
        }
    }
}