using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ReadModel.Queries.Contracts.Books.DataContracts
{
    public class SubTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? TypeId { get; set; }
        public TypeDto Type { get; set; }
        

    }
}
