using Application.DTOs.WorkoutClass;

namespace Application.Common.Interface.Services
{
    public interface IWorkoutClassService
    {
        Task<List<WorkoutClassDto>> GetAllWorkoutClassesAsync();

        Task<WorkoutClassDto?> GetWorkoutClassByIdAsync(int id);

        Task<int> AddWorkoutClassAsync(CreateWorkoutClassDto dto);

        Task<bool> UpdateWorkoutClassAsync(int id, UpdateWorkoutClassDto dto);

        Task<bool> DeleteWorkoutClassAsync(int id);
    }
}