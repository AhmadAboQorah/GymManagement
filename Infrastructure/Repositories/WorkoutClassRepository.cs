using Application.Common.Interface.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class WorkoutClassRepository : IWorkoutClassRepository
    {
        private readonly GymDbContext _context;

        public WorkoutClassRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutClass> AddWorkoutClassAsync(WorkoutClass workoutClass)
        {
            await _context.WorkoutClasses.AddAsync(workoutClass);
            await _context.SaveChangesAsync();
            return workoutClass;
        }

        public async Task<bool> DeleteWorkoutClassAsync(int id)
        {
            var workoutClass = await _context.WorkoutClasses.FindAsync(id);
            if (workoutClass == null)
                return false;

            _context.WorkoutClasses.Remove(workoutClass);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<WorkoutClass>> GetAllWorkoutClassesAsync()
        {
            return await _context.WorkoutClasses.ToListAsync();
        }

        public async Task<WorkoutClass?> GetWorkoutClassByIdAsync(int id)
        {
            return await _context.WorkoutClasses.FindAsync(id);
        }

        public async Task<WorkoutClass?> UpdateWorkoutClassAsync(WorkoutClass workoutClass)
        {
            var existingWorkoutClass = await _context.WorkoutClasses.FindAsync(workoutClass.Id);

            if (existingWorkoutClass == null)
                return null;

            existingWorkoutClass.ClassName = workoutClass.ClassName;
            existingWorkoutClass.Description = workoutClass.Description;
            existingWorkoutClass.TrainerId = workoutClass.TrainerId;
            existingWorkoutClass.Capacity = workoutClass.Capacity;
            existingWorkoutClass.StartTime = workoutClass.StartTime;
            existingWorkoutClass.EndTime = workoutClass.EndTime;
            existingWorkoutClass.Level = workoutClass.Level;

            await _context.SaveChangesAsync();

            return existingWorkoutClass;
        }
    }
    
}
