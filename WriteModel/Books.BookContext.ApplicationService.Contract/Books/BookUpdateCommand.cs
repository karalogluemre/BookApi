using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.ApplicationService.Contract.Books
{
    public class BookUpdateCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public Guid AuthorId { get; set; }
        public Guid SubTypeId { get; set; }
    }
}
