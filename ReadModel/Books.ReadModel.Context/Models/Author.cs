using System;
using System.Collections.Generic;

#nullable disable

namespace Books.ReadModel.Context.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
