using Domain.Domain;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Templates
{
    public class EntityRepository<TEntity, TId> : RepositoryImpl where TEntity : class
    {
        public EntityRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public virtual async Task<TEntity> GetAsync(TId id)
            => await DatabaseContext.Set<TEntity>().FindAsync(id);           
    
        public virtual async Task<bool> ExistAsync(TId id)
            => await GetAsync(id) != null;

        public virtual async Task<bool> ExistAsync(TEntity entity)
            => await ExistAsync(((Entity<TId>)entity).Id);

        public virtual void Create(TEntity entity)
            => DatabaseContext.Set<TEntity>().Add(entity);

        public virtual void Update(TEntity entity)
            => DatabaseContext.Entry(entity).State = EntityState.Modified;

        public virtual void Remove(TEntity entity)
            => DatabaseContext.Entry(entity).State = EntityState.Deleted;

    }
}
