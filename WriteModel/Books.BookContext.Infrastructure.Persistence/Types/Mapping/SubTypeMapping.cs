using Books.BookContext.Domain.Bookss;
using Books.BookContext.Domain.Types;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.Infrastructure.Persistence.Types.Mapping
{
    public class SubTypeMapping : EntityMappingBase<SubType>
    {
        public override void Initiate(EntityTypeBuilder<SubType> builder)
        {
            builder.HasMany<Book>()
                .WithOne()
                .HasForeignKey(x => x.SubTypeId)
                .IsRequired();
            builder.HasData(
                new SubType { Id = Guid.NewGuid(), Name = "Painting", TypeId = Guid.Parse("F3A92796-E896-47D3-8311-92F6ECC97F85") },
                new SubType { Id = Guid.NewGuid(), Name = "Poems", TypeId = Guid.Parse("F3A92796-E896-47D3-8311-92F6ECC97F85") },
                new SubType { Id = Guid.NewGuid(), Name = "Adventure", TypeId = Guid.Parse("F3A92796-E896-47D3-8311-92F6ECC97F85") },
                new SubType { Id = Guid.NewGuid(), Name = "Detective and Mystery", TypeId = Guid.Parse("6B27F3EE-ACC9-4CDA-BF3A-A7311B2C00CE") },
                new SubType { Id = Guid.NewGuid(), Name = "Fantasy", TypeId = Guid.Parse("6B27F3EE-ACC9-4CDA-BF3A-A7311B2C00CE") },
                new SubType { Id = Guid.NewGuid(), Name = "Horror", TypeId = Guid.Parse("6B27F3EE-ACC9-4CDA-BF3A-A7311B2C00CE") },
                new SubType { Id = Guid.NewGuid(), Name = "Literary Fiction", TypeId = Guid.Parse("6B27F3EE-ACC9-4CDA-BF3A-A7311B2C00CE") });
        }
    }
}
