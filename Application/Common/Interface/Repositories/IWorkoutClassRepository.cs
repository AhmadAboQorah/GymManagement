using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Common.Interface.Repositories
{
    public interface IWorkoutClassRepository
    {
        Task<List<WorkoutClass>> GetAllWorkoutClassesAsync();

        Task<WorkoutClass?> GetWorkoutClassByIdAsync(int id);

        Task<WorkoutClass> AddWorkoutClassAsync(WorkoutClass workoutClass);

        Task<bool> DeleteWorkoutClassAsync(int id);

        Task<WorkoutClass?> UpdateWorkoutClassAsync(WorkoutClass workoutClass);
    }
}
