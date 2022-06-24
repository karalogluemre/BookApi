using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.ApplicationService.Contract.Books
{
    public class BookCreateCommand : Command
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public Guid AuthorId { get; set; }
        public Guid SubTypeId { get; set; }
    }
}
