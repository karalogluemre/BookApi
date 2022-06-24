using Books.BookContext.ApplicationService.Contract.Books;
using Books.BookContext.Domain.Bookss.Services;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.ApplicationService.Books
{
    public class BookDeletCommandHandler : ICommandHandler<BookDeletCommand>
    {
        private readonly IBookRepository bookRepository;

        public BookDeletCommandHandler(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        public void Execute(BookDeletCommand command)
        {
            var book = bookRepository.GetBookById(command.Id);
            bookRepository.Remove(book);
        }
    }
}
