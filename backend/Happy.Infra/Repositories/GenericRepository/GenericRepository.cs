using Happy.Domain.Entities;
using Happy.Domain.Interfaces.Repositories;
using Happy.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Infra.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly MainContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<int> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Create(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            TEntity entity = _dbSet.Find(id);
            if (entity != null)
            {
                entity.Delete();
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Query().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Query()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Update(entity);
            _dbContext.Entry(entity).Property(x => x.EntryTime).IsModified = false;
            await _dbContext.SaveChangesAsync();
        }

        protected IQueryable<TEntity> Query()
        {
            return _dbSet.AsNoTracking().Where(c => !c.Deleted);
        }

        public virtual async Task<bool> EntityExists(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<bool> EntityExists(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}