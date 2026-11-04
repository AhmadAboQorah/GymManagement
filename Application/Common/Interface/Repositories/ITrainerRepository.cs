using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interface.Repositories
{
    using Domain.Entities;
        public interface ITrainerRepository
        {
            Task<List<Trainer>> GetAllTrainersAsync();

            Task<Trainer?> GetTrainerByIdAsync(int id);

            Task<Trainer> AddAsync(Trainer trainer);

            Task<Trainer?> UpdateAsync(Trainer trainer);

            Task<bool> DeleteAsync(int id);
        }
    
}

