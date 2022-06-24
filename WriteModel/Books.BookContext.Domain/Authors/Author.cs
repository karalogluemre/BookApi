using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Books.BookContext.Domain.Authors
{
    public class Author : EntityBase<Author>, IAggregateRoot<Author>
    {
        public string Name { get; set; }
        public IEnumerable<Expression<Func<Author, object>>> GetAggregateExpressions()
        {
            yield return null;
        }
    }
}
