using Application.Domain.Repository.Template;
using Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositories.Templates
{
    public class RepositoryImpl : Repository
    {
        protected DatabaseContext DatabaseContext;

        protected RepositoryImpl(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
    }
}
