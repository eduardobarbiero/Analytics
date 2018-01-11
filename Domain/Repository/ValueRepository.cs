using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Domain.Repository.Template;
using Domain.Domain;

namespace Application.Domain.Repository
{
    public interface ValueRepository : EntityRepository<Value, long>
    {
        Task<Value> GetAsync(long id);       

        Task<Value> GetByNameAsync(string name);
    }
}
