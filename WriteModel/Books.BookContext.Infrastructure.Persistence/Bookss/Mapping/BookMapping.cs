using Books.BookContext.Domain.Bookss;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.Infrastructure.Persistence.Bookss.Mapping
{
    public class BookMapping : EntityMappingBase<Book>
    {
        public override void Initiate(EntityTypeBuilder<Book> builder)
        {
            
        }
    }
}
