using Application.Common.Interface.Repositories;
using Application.Common.Interface.Services;
using Application.DTOs.Trainer;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }


        public async Task<List<TrainerDto>> GetAllTrainersAsync()
        {
            var trainers = await _trainerRepository.GetAllTrainersAsync();

            return trainers.Select(t => new TrainerDto
            {
                Id = t.Id,
                FullName = t.FullName,
                Phone = t.Phone,
                Email = t.Email,
                Specialty = (Domain.Enums.TrainerSpecialty)t.Specialty,
                ExperienceYears = t.ExperienceYears,
                Salary = t.Salary,
                HireDate = t.HireDate

            }).ToList();
        }



        public async Task<TrainerDto?> GetTrainerByIdAsync(int id)
        {
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);

            if (trainer == null)
                return null;


            return new TrainerDto
            {
                Id = trainer.Id,
                FullName = trainer.FullName,
                Phone = trainer.Phone,
                Email = trainer.Email,
                Specialty = (Domain.Enums.TrainerSpecialty)trainer.Specialty,
                ExperienceYears = trainer.ExperienceYears,
                Salary = trainer.Salary,
                HireDate = trainer.HireDate
            };
        }



        public async Task<int> AddAsync(CreateTrainerDto dto)
        {
            var trainer = new Trainer
            {
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                Specialty = (Domain.Enums.TrainerSpecialty)dto.Specialty,
                ExperienceYears = dto.ExperienceYears,
                Salary = dto.Salary,
                HireDate = dto.HireDate
            };


            var result = await _trainerRepository.AddAsync(trainer);

            return result.Id;
        }




        public async Task<bool> UpdateAsync(int id, UpdateTrainerDto dto)
        {
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);

            if (trainer == null)
                return false;


            trainer.FullName = dto.FullName;
            trainer.Phone = dto.Phone;
            trainer.Email = dto.Email;
            trainer.Specialty = (Domain.Enums.TrainerSpecialty)dto.Specialty;
            trainer.ExperienceYears = dto.ExperienceYears;
            trainer.Salary = dto.Salary;
            trainer.HireDate = dto.HireDate;


            var result = await _trainerRepository.UpdateAsync(trainer);

            return result != null;
        }




        public async Task<bool> DeleteAsync(int id)
        {
            return await _trainerRepository.DeleteAsync(id);
        }
    }
}