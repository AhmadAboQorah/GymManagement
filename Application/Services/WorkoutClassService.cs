using Application.Common.Interface.Repositories;
using Application.Common.Interface.Services;
using Application.DTOs.WorkoutClass;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class WorkoutClassService : IWorkoutClassService
    {
        private readonly IWorkoutClassRepository _workoutClassRepository;


        public WorkoutClassService(
            IWorkoutClassRepository workoutClassRepository)
        {
            _workoutClassRepository = workoutClassRepository;
        }



        public async Task<List<WorkoutClassDto>> GetAllWorkoutClassesAsync()
        {
            var classes =
                await _workoutClassRepository.GetAllWorkoutClassesAsync();


            return classes.Select(c => new WorkoutClassDto
            {
                Id = c.Id,
                ClassName = c.ClassName,
                Description = c.Description,
                TrainerId = c.TrainerId,
                Capacity = c.Capacity,
                StartTime = c.StartTime,
                EndTime = c.EndTime,
                Level = c.Level

            }).ToList();
        }




        public async Task<WorkoutClassDto?> GetWorkoutClassByIdAsync(int id)
        {
            var workoutClass =
                await _workoutClassRepository.GetWorkoutClassByIdAsync(id);


            if (workoutClass == null)
                return null;


            return new WorkoutClassDto
            {
                Id = workoutClass.Id,
                ClassName = workoutClass.ClassName,
                Description = workoutClass.Description,
                TrainerId = workoutClass.TrainerId,
                Capacity = workoutClass.Capacity,
                StartTime = workoutClass.StartTime,
                EndTime = workoutClass.EndTime,
                Level = workoutClass.Level
            };
        }





        public async Task<int> AddWorkoutClassAsync(
            CreateWorkoutClassDto dto)
        {

            var workoutClass = new WorkoutClass
            {
                ClassName = dto.ClassName,
                Description = dto.Description,
                TrainerId = dto.TrainerId,
                Capacity = dto.Capacity,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Level = dto.Level
            };


            var result =
                await _workoutClassRepository
                .AddWorkoutClassAsync(workoutClass);


            return result.Id;
        }





        public async Task<bool> UpdateWorkoutClassAsync(
            int id,
            UpdateWorkoutClassDto dto)
        {

            var workoutClass =
                await _workoutClassRepository
                .GetWorkoutClassByIdAsync(id);


            if (workoutClass == null)
                return false;



            workoutClass.ClassName = dto.ClassName;
            workoutClass.Description = dto.Description;
            workoutClass.TrainerId = dto.TrainerId;
            workoutClass.Capacity = dto.Capacity;
            workoutClass.StartTime = dto.StartTime;
            workoutClass.EndTime = dto.EndTime;
            workoutClass.Level = dto.Level;



            var result =
                await _workoutClassRepository
                .UpdateWorkoutClassAsync(workoutClass);


            return result != null;
        }





        public async Task<bool> DeleteWorkoutClassAsync(int id)
        {
            return await _workoutClassRepository
                .DeleteWorkoutClassAsync(id);
        }
    }
}