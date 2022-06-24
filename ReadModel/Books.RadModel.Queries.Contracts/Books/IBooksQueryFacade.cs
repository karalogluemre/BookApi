using Books.ReadModel.Queries.Contracts.Books.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ReadModel.Queries.Contracts.Books
{
    public interface IBooksQueryFacade
    {
        IList<TypeDto> GetTypes();
        IList<AuthorDto> GetAuthors();
        IList<SubTypeDto> GetSubTypesForType(Guid id);
        IList<BookListDto> GetBooks(Guid? typeId, Guid? subTypeId, Guid? authorId, string name = "");
        IList<BookListDto> GetBooksWithStoreProcedure(Guid? typeId, Guid? subTypeId, Guid? authorId, string name = "");

    }
}
