using Application.DTOs.Trainer;

namespace Application.Common.Interface.Services
{
    public interface ITrainerService
    {
        Task<List<TrainerDto>> GetAllTrainersAsync();

        Task<TrainerDto?> GetTrainerByIdAsync(int id);

        Task<int> AddAsync(CreateTrainerDto dto);

        Task<bool> UpdateAsync(int id, UpdateTrainerDto dto);

        Task<bool> DeleteAsync(int id);
    }
}