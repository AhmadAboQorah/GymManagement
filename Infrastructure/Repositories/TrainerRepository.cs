using Application.Common.Interface.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly GymDbContext _context;

        public TrainerRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<Trainer> AddAsync(Trainer trainer)
        {
            await _context.Trainers.AddAsync(trainer);
            await _context.SaveChangesAsync();

            return trainer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);

            if (trainer == null)
                return false;

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Trainer>> GetAllTrainersAsync()
        {
            return await _context.Trainers
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<Trainer?> GetTrainerByIdAsync(int id)
        {
            return await _context.Trainers
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Trainer?> UpdateAsync(Trainer trainer)
        {
            var existingTrainer = await _context.Trainers.FindAsync(trainer.Id);

            if (existingTrainer == null)
                return null;

            _context.Entry(existingTrainer).CurrentValues.SetValues(trainer);

            await _context.SaveChangesAsync();

            return existingTrainer;
        }
    }
}