using Application.Common.Interface.Services;
using Application.DTOs.WorkoutClass;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutClassController : ControllerBase
    {
        private readonly IWorkoutClassService _workoutClassService;


        public WorkoutClassController(
            IWorkoutClassService workoutClassService)
        {
            _workoutClassService = workoutClassService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var classes =
                await _workoutClassService.GetAllWorkoutClassesAsync();

            return Ok(classes);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var workoutClass =
                await _workoutClassService
                .GetWorkoutClassByIdAsync(id);


            if (workoutClass == null)
                return NotFound();


            return Ok(workoutClass);
        }




        [HttpPost]
        public async Task<IActionResult> Create(
            CreateWorkoutClassDto dto)
        {
            var id =
                await _workoutClassService
                .AddWorkoutClassAsync(dto);


            return Ok(new
            {
                Message = "Workout class created successfully",
                Id = id
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateWorkoutClassDto dto)
        {

            var result =
                await _workoutClassService
                .UpdateWorkoutClassAsync(id, dto);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Workout class updated successfully"
            });
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result =
                await _workoutClassService
                .DeleteWorkoutClassAsync(id);


            if (!result)
                return NotFound();


            return Ok(new
            {
                Message = "Workout class deleted successfully"
            });
        }
    }
}