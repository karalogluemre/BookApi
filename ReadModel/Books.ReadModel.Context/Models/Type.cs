using System;
using System.Collections.Generic;

#nullable disable

namespace Books.ReadModel.Context.Models
{
    public partial class Type
    {
        public Type()
        {
            SubTypes = new HashSet<SubType>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubType> SubTypes { get; set; }
    }
}
