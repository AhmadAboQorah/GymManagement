using Application.Common.Interface.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly GymDbContext _context;

        public MemberRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckPhoneExistsAsync(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;

            return await _context.Members.AnyAsync(m => m.Phone == phone);
        }

        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await _context.Members.Include(m => m.User).Include(t => t.Subscriptions).Include(m => m.Subscriptions).ToListAsync();
        }

        public async Task<Member?> GetMemberByIdAsync(int memberId)
        {
            return await _context.Members.Include(m => m.User).FirstOrDefaultAsync(m => m.Id == memberId);
        }

        public async Task<Member?> GetMemberByNameAsync(string name)
        {
            return await _context.Members.Include(m => m.User).FirstOrDefaultAsync(m => m.FullName == name);
        }

        public async Task<Member?> GetMemberByPhoneAsync(string phone)
        {
            return await _context.Members.Include(m => m.User).FirstOrDefaultAsync(m => m.Phone == phone);
        }

        

        public async Task<List<ClassReservation>> GetMemberReservationsAsync(int memberId)
        {
            return await _context.ClassReservations.Where(r => r.MemberId == memberId).ToListAsync();
        }

        public async Task<List<Subscription>> GetMemberSubscriptionsAsync(int memberId)
        {
            return await _context.Subscriptions.Where(s => s.MemberId == memberId).ToListAsync();
        }
        public async Task<Member> AddAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

            return member;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
                return false;

            _context.Members.Remove(member);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Member?> UpdateAsync(Member member)
        {
            var existingMember =
                await _context.Members.FindAsync(member.Id);


            if (existingMember == null)
                return null;


            existingMember.FullName = member.FullName;
            existingMember.Phone = member.Phone;
            existingMember.BirthDate = member.BirthDate;
            existingMember.Gender = member.Gender;
            existingMember.JoinDate = member.JoinDate;


            await _context.SaveChangesAsync();

            return existingMember;
        }

    }
}

