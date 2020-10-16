using Happy.Domain.Entities;
using Happy.Domain.Interfaces.Repositories;
using Happy.Infra.Context;
using Happy.Infra.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Happy.Infra.Repositories.EntityRepositories
{
    public class OrphanageRepository : GenericRepository<Orphanage>, IOrphanageRepository
    {
        public OrphanageRepository(MainContext mainContext) : base(mainContext)
        {
        }

        public override Task<bool> EntityExists(int id)
        {
            return _dbContext.Orphanages
               .AnyAsync(c => c.Id == id && !c.Deleted);
        }

        public override Task<bool> EntityExists(Orphanage entity)
        {
            return _dbContext.Orphanages
                .AllAsync(c => c.Id == entity.Id || c.Name == entity.Name);
        }
    }
}