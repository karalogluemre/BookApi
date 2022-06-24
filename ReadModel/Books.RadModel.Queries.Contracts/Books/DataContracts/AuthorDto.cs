using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ReadModel.Queries.Contracts.Books.DataContracts
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
