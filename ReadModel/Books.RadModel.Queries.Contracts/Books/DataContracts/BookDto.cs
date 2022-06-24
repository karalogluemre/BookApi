using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ReadModel.Queries.Contracts.Books.DataContracts
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public Guid SubTypeId { get; set; }
        public Guid AuthorId { get; set; }

        public virtual AuthorDto Author { get; set; }
        public virtual SubTypeDto SubType { get; set; }
    }
}
