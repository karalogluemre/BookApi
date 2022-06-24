using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.ApplicationService.Contract.Books
{
    public class BookDeletCommand : Command
    {
        public Guid Id { get; set; }
    }
}
