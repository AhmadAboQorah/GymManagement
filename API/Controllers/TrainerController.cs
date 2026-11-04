using Application.Common.Interface.Services;
using Application.DTOs.Trainer;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;


        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers =
                await _trainerService.GetAllTrainersAsync();

            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trainer =
                await _trainerService.GetTrainerByIdAsync(id);


            if (trainer == null)
                return NotFound();


            return Ok(trainer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateTrainerDto dto)
        {
            var id =
                await _trainerService.AddAsync(dto);


            return Ok(new
            {
                Message = "Trainer created successfully",
                Id = id
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateTrainerDto dto)
        {

            var result =
                await _trainerService.UpdateAsync(id, dto);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Trainer updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result =
                await _trainerService.DeleteAsync(id);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Trainer deleted successfully"
            });
        }
    }
}