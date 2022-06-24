using Books.BookContext.ApplicationService.Contract.Books;
using Books.BookContext.Facade.Contract;
using Framework.Core.Application;
using Framework.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.Facade
{
    [Route("library/api/Book/[action]")]
    [ApiController]
    public class BookCommandFacade : FacadeCommandBase, IBookCommandFacade
    {
        public BookCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        [HttpPost]
        public void CreateBook(BookCreateCommand command)
        {
            CommandBus.Dispatch(command);
        
        }
        [HttpPost]
        public void UpdateBook(BookUpdateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        [HttpPost]
        public void DeleteBook(BookDeletCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
