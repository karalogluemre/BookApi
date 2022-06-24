using Books.BookContext.Domain.Bookss;
using Books.BookContext.Domain.Bookss.Services;
using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Linq;

namespace Books.BookContext.Infrastructure.Persistence.Bookss
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateBook(Book book)
        {
            Create(book);
        }

        public Book GetBookById(Guid id)
        {
            var book = Set.Single(x=>x.Id == id);
            return book;
        }

        public void Remove(Book book)
        {
            DbContext.Set<Book>().Remove(book);
        }
    }
}
