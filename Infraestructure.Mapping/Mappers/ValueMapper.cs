using Domain.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class ValueMapper
    {
        public static void CreateMapping(EntityTypeBuilder<Value> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(value => value.Name);
        }
    }
}