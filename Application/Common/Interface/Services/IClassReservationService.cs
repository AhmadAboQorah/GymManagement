using Application.DTOs.ClassReservation;

namespace Application.Common.Interface.Services
{
    public interface IClassReservationService
    {
        Task<List<ReservationDto>> GetAllReservationsAsync();

        Task<ReservationDto?> GetReservationByIdAsync(int id);

        Task<int> AddReservationAsync(CreateReservationDto dto);

        Task<bool> UpdateReservationAsync(int id, UpdateReservationDto dto);

        Task<bool> DeleteReservationAsync(int id);
    }
}