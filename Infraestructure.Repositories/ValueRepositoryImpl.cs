using Application.Domain.Repository;
using Application.Domain.Repository.Template;
using Domain.Domain;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    class ValueRepositoryImpl : Templates.EntityRepository<Value, long>, ValueRepository
    {

        public ValueRepositoryImpl(DatabaseContext databaseContext) : base(databaseContext)
        {            
        }

        public override async Task<Value> GetAsync(long id)
           => await DatabaseContext.Values
                    .Include(w => w.ValueWorks)
                    .FirstOrDefaultAsync(val => val.Id == id);

        public async Task<Value> GetByNameAsync(string name)
            => await DatabaseContext.Values.FirstOrDefaultAsync(val => val.Name == name);
    }
}
