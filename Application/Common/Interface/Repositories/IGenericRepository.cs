using Domain.Entities;

namespace Application.Common.Interface.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity?> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);
    }
}