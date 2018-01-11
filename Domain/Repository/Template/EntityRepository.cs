using System;
using System.Threading.Tasks;
using Domain.Domain;

namespace Application.Domain.Repository.Template
{
    public interface EntityRepository<TEntity, in TId> : Repository where TEntity : Entity<TId>
    {
        Task<TEntity> GetAsync(TId id);

        Task<bool> ExistAsync(TId id);

        Task<bool> ExistAsync(TEntity entity);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
