using System;
using System.Threading.Tasks;

namespace Application.Domain.Repository
{
    public interface UnitOfWork : IDisposable
    {
        ValueRepository Values { get; }

        Task<int> CommitAsync();

        int Commit();
    }
}