using Application.Domain.Repository;
using Infrastructure.Config;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    class UnitOfWorkImpl : UnitOfWork
    {

        private readonly DatabaseContext databaseContext;

        public UnitOfWorkImpl(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            Values = new ValueRepositoryImpl(databaseContext);
           
        }
         
        public ValueRepository Values { get; }

        public virtual async Task<int> CommitAsync()
        {
            return await databaseContext.SaveChangesAsync();
        }

        public int Commit()
        {
            return databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            databaseContext.Dispose();
        }

    }
}
