using Application.Common.Interface.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ClassReservationRepository : IClassReservationRepository
    {
        private readonly GymDbContext _context;

        public ClassReservationRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<ClassReservation> AddReservationAsync(ClassReservation reservation)
        {
            await _context.ClassReservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var reservation = await _context.ClassReservations.FindAsync(id);
            if (reservation == null)
                return false;

            _context.ClassReservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ClassReservation>> GetAllReservationsAsync()
        {
            return await _context.ClassReservations.ToListAsync();
        }

        public async Task<ClassReservation?> GetReservationByIdAsync(int id)
        {
            return await _context.ClassReservations.FindAsync(id);
        }

        public async Task<ClassReservation?> UpdateReservationAsync(ClassReservation reservation)
        {
            var existingReservation = await _context.ClassReservations.FindAsync(reservation.Id);

            if (existingReservation == null)
                return null;

            existingReservation.MemberId = reservation.MemberId;
            existingReservation.WorkoutClassId = reservation.WorkoutClassId;
            existingReservation.MembershipPlanId = reservation.MembershipPlanId;
            existingReservation.ReservationDate = reservation.ReservationDate;
            existingReservation.AttendanceStatus = reservation.AttendanceStatus;

            await _context.SaveChangesAsync();

            return existingReservation;
        }
    }
    
}
