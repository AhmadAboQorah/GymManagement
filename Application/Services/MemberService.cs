using Application.Common.Interface.Repositories;
using Application.Common.Interface.Services;
using Application.DTOs.Member;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class MemberService : IMemberService

    {

        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<List<MemberDto>> GetAllMembersAsync()
        {
            var members = await _memberRepository.GetAllMembersAsync();

            return members.Select(m => new MemberDto
            {
                Id = m.Id,
                FullName = m.FullName,
                Phone = m.Phone,
                BirthDate = m.BirthDate,
                Gender = m.Gender,
                JoinDate = m.JoinDate
            }).ToList();
        }

        public async Task<MemberDto?> GetMemberByIdAsync(int id)
        {
            var member = await _memberRepository.GetMemberByIdAsync(id);

            if (member == null)
                return null;

            return new MemberDto
            {
                Id = member.Id,
                FullName = member.FullName,
                Phone = member.Phone,
                BirthDate = member.BirthDate,
                Gender = member.Gender,
                JoinDate = member.JoinDate
            };
        }

        public async Task<int> AddAsync(int userId, CreateMemberDto dto)
        {
            var phoneExists = await _memberRepository.CheckPhoneExistsAsync(dto.Phone);

            if (phoneExists)
                throw new Exception("Phone number already exists.");

            var member = new Member
            {
                UserId = userId,
                FullName = dto.FullName,
                Phone = dto.Phone,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                JoinDate = dto.JoinDate
            };

            var result = await _memberRepository.AddAsync(member);

            return result.Id;
        }

        public async Task<List<ClassReservation>> GetMemberReservationsAsync(int memberId)
        {
            return await _memberRepository.GetMemberReservationsAsync(memberId);
        }


        public async Task<List<Subscription>> GetMemberSubscriptionsAsync(int memberId)
        {
            return await _memberRepository.GetMemberSubscriptionsAsync(memberId);
        }
        public async Task<bool> UpdateAsync(
    int id,
    UpdateMemberDto dto)
        {
            var member =
                await _memberRepository.GetMemberByIdAsync(id);

            if (member == null)
                return false;


            if (member.Phone != dto.Phone)
            {
                var phoneExists =
                    await _memberRepository.CheckPhoneExistsAsync(dto.Phone);

                if (phoneExists)
                    throw new Exception("Phone number already exists.");
            }


            member.FullName = dto.FullName;
            member.Phone = dto.Phone;
            member.BirthDate = dto.BirthDate;
            member.Gender = dto.Gender;
            member.JoinDate = dto.JoinDate;


            var result =
                await _memberRepository.UpdateAsync(member);


            return result != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _memberRepository.DeleteAsync(id);
        }
    }
    
}

