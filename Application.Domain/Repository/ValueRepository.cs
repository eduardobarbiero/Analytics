using System;
using Application.Domain.Domain;
using Application.Domain.Repository.Template;

namespace Application.Domain.Repository
{
    public interface ValueRepository : EntityRepository<Value, long>
    {
        
    }
}
