using Books.BookContext.Domain.Types;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Type = Books.BookContext.Domain.Types.Type;

namespace Books.BookContext.Infrastructure.Persistence.Types.Mapping
{
    public class TypeMapping : EntityMappingBase<Type>
    {
        public override void Initiate(EntityTypeBuilder<Type> builder)
        {
            builder.HasData(
                new Type
                {
                    Id = Guid.Parse("F3A92796-E896-47D3-8311-92F6ECC97F85"),
                    Name = "Children"
                },
                new Type
                {
                    Id = Guid.Parse("6B27F3EE-ACC9-4CDA-BF3A-A7311B2C00CE"),
                    Name = "Adult"
                });
            

        }
    }
}
