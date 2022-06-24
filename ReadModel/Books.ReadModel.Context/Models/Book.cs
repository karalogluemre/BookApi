using System;
using System.Collections.Generic;

#nullable disable

namespace Books.ReadModel.Context.Models
{
    public partial class Book
    {
        public Book()
        {
            Readers = new HashSet<Reader>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public Guid SubTypeId { get; set; }
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual SubType SubType { get; set; }
        public virtual ICollection<Reader> Readers { get; set; }
    }
}
