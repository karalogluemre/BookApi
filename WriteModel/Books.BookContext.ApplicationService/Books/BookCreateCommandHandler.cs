using Books.BookContext.ApplicationService.Contract.Books;
using Books.BookContext.Domain.Bookss;
using Books.BookContext.Domain.Bookss.Services;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.ApplicationService.Books
{
    public class BookCreateCommandHandler : ICommandHandler<BookCreateCommand>
    {
        private readonly IBookRepository bookRepository;

        public BookCreateCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Execute(BookCreateCommand command)
        {
            var book = new Book(command.Name, command.PageCount, command.SubTypeId, command.AuthorId);
            bookRepository.CreateBook(book);
        }
    }
}
