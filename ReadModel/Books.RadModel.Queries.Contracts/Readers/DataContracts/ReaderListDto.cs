using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ReadModel.Queries.Contracts.Readers.DataContracts
{
    public class ReaderListDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BookName { get; set; }
    }
}
