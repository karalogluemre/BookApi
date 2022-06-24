using Books.BookContext.ApplicationService.Contract.Books;
using Books.BookContext.Domain.Bookss.Services;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.ApplicationService.Books
{
    public class BookUpdateCommandHandler : ICommandHandler<BookUpdateCommand>
    {
        private readonly IBookRepository _bookRepository;
        public BookUpdateCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public void Execute(BookUpdateCommand command)
        {
           var findedBook = _bookRepository.GetBookById(command.Id);
            findedBook.UpdateBook(command.Name, command.AuthorId, command.PageCount, command.SubTypeId);
        }
    }
}
