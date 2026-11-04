using Application.Common.Interface.Repositories;
using Application.Common.Interface.Services;
using Application.DTOs.ClassReservation;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class ClassReservationService : IClassReservationService
    {
        private readonly IClassReservationRepository _reservationRepository;


        public ClassReservationService(
            IClassReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }



        public async Task<List<ReservationDto>> GetAllReservationsAsync()
        {
            var reservations =
                await _reservationRepository.GetAllReservationsAsync();


            return reservations.Select(r => new ReservationDto
            {
                Id = r.Id,
                MemberId = r.MemberId,
                WorkoutClassId = r.WorkoutClassId,
                ReservationDate = r.ReservationDate,
                AttendanceStatus = r.AttendanceStatus

            }).ToList();
        }




        public async Task<ReservationDto?> GetReservationByIdAsync(int id)
        {
            var reservation =
                await _reservationRepository.GetReservationByIdAsync(id);


            if (reservation == null)
                return null;


            return new ReservationDto
            {
                Id = reservation.Id,
                MemberId = reservation.MemberId,
                WorkoutClassId = reservation.WorkoutClassId,
                ReservationDate = reservation.ReservationDate,
                AttendanceStatus = reservation.AttendanceStatus
            };
        }





        public async Task<int> AddReservationAsync(
            CreateReservationDto dto)
        {

            var reservation = new ClassReservation
            {
                MemberId = dto.MemberId,
                WorkoutClassId = dto.WorkoutClassId,
                ReservationDate = dto.ReservationDate,
                AttendanceStatus = dto.AttendanceStatus
            };


            var result =
                await _reservationRepository.AddReservationAsync(reservation);


            return result.Id;
        }






        public async Task<bool> UpdateReservationAsync(
            int id,
            UpdateReservationDto dto)
        {

            var reservation =
                await _reservationRepository.GetReservationByIdAsync(id);


            if (reservation == null)
                return false;



            reservation.AttendanceStatus = dto.AttendanceStatus;



            var result =
                await _reservationRepository.UpdateReservationAsync(reservation);


            return result != null;
        }





        public async Task<bool> DeleteReservationAsync(int id)
        {
            return await _reservationRepository
                .DeleteReservationAsync(id);
        }
    }
}