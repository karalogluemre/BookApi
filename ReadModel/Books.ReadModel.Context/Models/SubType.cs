using System;
using System.Collections.Generic;

#nullable disable

namespace Books.ReadModel.Context.Models
{
    public partial class SubType
    {
        public SubType()
        {
            Books = new HashSet<Book>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
