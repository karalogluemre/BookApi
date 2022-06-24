using Books.BookContext.ApplicationService.Contract.Books;

namespace Books.BookContext.Facade.Contract
{
    public interface IBookCommandFacade
    {
        void CreateBook(BookCreateCommand command);
    }
}
