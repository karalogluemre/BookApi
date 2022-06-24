namespace Books.ReadModel.Queries.Contracts.Books.DataContracts
{
    public class BookListDto
    {
        public string Name { get; set; }
        public int pageCount { get; set; }
        public string AuthorName { get; set; }
        public string TypeName { get; set; }
        public string SubTypeName { get; set; }
    }
}
