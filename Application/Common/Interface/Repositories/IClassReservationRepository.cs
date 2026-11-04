using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Common.Interface.Repositories
{
 public interface IClassReservationRepository
    {
        Task<List<ClassReservation>> GetAllReservationsAsync();

        Task<ClassReservation?> GetReservationByIdAsync(int id);

        Task<ClassReservation> AddReservationAsync(ClassReservation reservation);

        Task<bool> DeleteReservationAsync(int id);

        Task<ClassReservation?> UpdateReservationAsync(ClassReservation reservation);
    }
}