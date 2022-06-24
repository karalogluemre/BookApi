using Books.BookContext.Domain.Bookss;
using Books.BookContext.Domain.Readers;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.Infrastructure.Persistence.Readers.Mapping
{
    public class ReaderMapping : EntityMappingBase<Reader>
    {

        public override void Initiate(EntityTypeBuilder<Reader> builder)
        {
            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey(x => x.BookId).IsRequired();
        }
    }
}
