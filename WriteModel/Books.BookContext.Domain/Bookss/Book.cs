using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Books.BookContext.Domain.Bookss
{
    public class Book : EntityBase<Book>, IAggregateRoot<Book>
    {

        public Book() { }
        public Book(string name, int pageCount, Guid subTypeId, Guid authorId)
        {
            SetId();
            Name = name;
            PageCount = pageCount;
            SubTypeId = subTypeId;
            AuthorId = authorId;
        }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public Guid SubTypeId { get; set; }
        public Guid AuthorId { get; set; }

        public IEnumerable<Expression<Func<Book, object>>> GetAggregateExpressions()
        {
            yield return null;
        }

        public void UpdateBook(string name, Guid authorId, int pageCount, Guid subTypeId)
        {
            Name = name;
            PageCount = pageCount;
            SubTypeId = subTypeId;
            AuthorId = authorId;
        }
    }
}
