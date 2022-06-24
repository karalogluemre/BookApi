using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BookContext.Domain.Types
{
    public class SubType : EntityBase<SubType>
    {
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public Type Type { get; set; }
    }
}
