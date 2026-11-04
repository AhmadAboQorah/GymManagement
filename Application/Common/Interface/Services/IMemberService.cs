using Application.DTOs.Member;
using Domain.Entities;

namespace Application.Common.Interface.Services
{
    public interface IMemberService
    {
        Task<List<MemberDto>> GetAllMembersAsync();

        Task<MemberDto?> GetMemberByIdAsync(int id);

        Task<int> AddAsync(int userId, CreateMemberDto dto);

        Task<bool> UpdateAsync(int id, UpdateMemberDto dto);

        Task<bool> DeleteAsync(int id);

        Task<List<ClassReservation>> GetMemberReservationsAsync(int memberId);

        Task<List<Subscription>> GetMemberSubscriptionsAsync(int memberId);
    }
}