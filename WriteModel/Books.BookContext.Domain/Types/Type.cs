using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Books.BookContext.Domain.Types
{
    public class Type : EntityBase<Type>, IAggregateRoot<Type>
    {
        public string Name { get; set; }
        public ICollection<SubType> SubTypes { get; set; } = new HashSet<SubType>();
        public IEnumerable<Expression<Func<Type, object>>> GetAggregateExpressions()
        {
            yield return a => a.SubTypes;
        }
    }
}
