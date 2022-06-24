using Books.BookContext.Domain.Authors;
using Books.BookContext.Domain.Bookss;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.Infrastructure.Persistence.Authors.Mapping
{
    public class AuthorMappung : EntityMappingBase<Author>
    {
        public override void Initiate(EntityTypeBuilder<Author> builder)
        {
            builder.HasMany<Book>()
                .WithOne()
                .HasForeignKey(x => x.AuthorId)
                .IsRequired();

            builder.HasData(
                new Author {Id=Guid.NewGuid(), Name = "William Shakespeare" },
                new Author {Id=Guid.NewGuid(), Name = "William Faulkner" },
                new Author {Id=Guid.NewGuid(), Name = "Henry James" },
                new Author {Id=Guid.NewGuid(), Name = "Jane Austen" }
                );


        }
    }
}
