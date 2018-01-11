using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class ValueMapper
    {
        public static void CreateMapping(EntityTypeBuilder<Value> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(value => value.Name);
            entityTypeBuilder.Property(value => value.CreatedAt).IsRequired();
            entityTypeBuilder.HasMany(t => t.ValueWorks).WithOne(v => v.Value).HasForeignKey(i => i.ValueId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}