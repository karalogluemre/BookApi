using Books.BookContext.Domain.Readers;
using Books.BookContext.Domain.Readers.Services;
using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.Infrastructure.Persistence.Readers
{
    public class ReaderRepository : RepositoryBase<Reader>, IReaderRepository
    {
        public ReaderRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
