using Application.Domain.Repository;
using Application.Domain.Repository.Template;
using Domain.Domain;
using Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositories
{
    class ValueRepositoryImpl : Templates.EntityRepository<Value, long>, ValueRepository
    {
        private DatabaseContext databaseContext;

        public ValueRepositoryImpl(DatabaseContext databaseContext) : base(databaseContext)
        {            
        }
    }
}
