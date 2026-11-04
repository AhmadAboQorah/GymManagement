using Domain.Entities;

namespace Application.Common.Interface.Repositories
{
    public interface IMemberRepository
    {
        Task<Member> AddAsync(Member member);

        Task<bool> DeleteAsync(int id);

        Task<Member?> UpdateAsync(Member member);


        Task<bool> CheckPhoneExistsAsync(string phone);

        Task<List<Member>> GetAllMembersAsync();

        Task<Member?> GetMemberByIdAsync(int memberId);

        Task<Member?> GetMemberByNameAsync(string name);

        Task<Member?> GetMemberByPhoneAsync(string phone);


        Task<List<ClassReservation>> GetMemberReservationsAsync(int memberId);

        Task<List<Subscription>> GetMemberSubscriptionsAsync(int memberId);
    }
}