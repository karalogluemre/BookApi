using Framework.Core.Persistence;
using System;

namespace Books.BookContext.Domain.Bookss.Services
{
    public interface IBookRepository : IRepository<Book>
    {
        void CreateBook(Book book);

        Book GetBookById(Guid id);
        void Remove(Book book);
    }
}
