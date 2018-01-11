using System;
using Application.Domain.Repository.Template;
using Domain.Domain;

namespace Application.Domain.Repository
{
    public interface ValueRepository : EntityRepository<Value, long>
    {
        
    }
}
