using System;
using System.Collections.Generic;

#nullable disable

namespace Books.ReadModel.Context.Models
{
    public partial class Reader
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
