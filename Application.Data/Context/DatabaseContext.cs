using System;
using System.Linq;
using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructures.Data.ObjectRelational.Config.Context
{
    public class DatabaseContext
    {
        public DatabaseContext()
        {
        }

        public DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RemoveCascadeDelete(modelBuilder);

        }

        private static void RemoveCascadeDelete(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    
}