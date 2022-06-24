using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Books.BookContext.Domain.Readers
{
    public class Reader : EntityBase<Reader>, IAggregateRoot<Reader>
    {
        public Reader() { }
        public Reader(string firstName, string lastName, DateTime purchaseDate, Guid bookId)
        {
            SetId();
            FirstName = firstName;
            LastName = lastName;
            PurchaseDate = purchaseDate;
            BookId = bookId;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PurchaseDate  { get; set; }
        public Guid BookId { get; set; }
        public IEnumerable<Expression<Func<Reader, object>>> GetAggregateExpressions()
        {
            yield return null;
        }
    }
}
