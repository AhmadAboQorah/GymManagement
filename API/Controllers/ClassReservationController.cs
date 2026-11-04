using Application.Common.Interface.Services;
using Application.DTOs.ClassReservation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassReservationController : ControllerBase
    {
        private readonly IClassReservationService _reservationService;


        public ClassReservationController(
            IClassReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservations =
                await _reservationService.GetAllReservationsAsync();

            return Ok(reservations);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation =
                await _reservationService.GetReservationByIdAsync(id);


            if (reservation == null)
                return NotFound();


            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateReservationDto dto)
        {
            var id =
                await _reservationService.AddReservationAsync(dto);


            return Ok(new
            {
                Message = "Reservation created successfully",
                Id = id
            });
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateReservationDto dto)
        {

            var result =
                await _reservationService
                .UpdateReservationAsync(id, dto);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Reservation updated successfully"
            });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result =
                await _reservationService
                .DeleteReservationAsync(id);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Reservation deleted successfully"
            });
        }
    }
}