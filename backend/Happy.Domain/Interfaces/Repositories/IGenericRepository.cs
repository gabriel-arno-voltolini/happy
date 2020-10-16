using Happy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Domain.Interfaces.Repositories
{
    interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);

        Task<int> Create(TEntity entity);

        Task Create(IEnumerable<TEntity> entities);

        Task Update(TEntity entity);

        Task Delete(int id);

        Task<List<TEntity>> GetAll();

        Task<bool> EntityExists(TEntity entity);

        Task<bool> EntityExists(int id);
    }
}
