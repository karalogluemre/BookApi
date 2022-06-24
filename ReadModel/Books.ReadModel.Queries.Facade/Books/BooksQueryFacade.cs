using Books.ReadModel.Context.Models;
using Books.ReadModel.Queries.Contracts.Books;
using Books.ReadModel.Queries.Contracts.Books.DataContracts;
using Framework.Core.Mapper;
using Framework.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.ReadModel.Queries.Facade.Books
{
    [Route("library/api/Books/[action]")]
    [ApiController]
    public class BooksQueryFacade : FacadeQueryBase, IBooksQueryFacade
    {
        private readonly LibraryContext db;
        private readonly IMapper mapper;

        public BooksQueryFacade(LibraryContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public IList<TypeDto> GetTypes()
        {
            return mapper.Map<TypeDto, Context.Models.Type>(db.Types.ToList());
        }
        [HttpGet]
        public IList<AuthorDto> GetAuthors()
        {
            return mapper.Map<AuthorDto, Author>(db.Authors.ToList());
        }
        [HttpGet]
        public IList<SubTypeDto> GetSubTypesForType(Guid id)
        {
            return mapper.Map<SubTypeDto, SubType>(db.SubTypes.Where(x => x.TypeId == id).ToList());
        }

        [HttpGet]
        public IList<BookListDto> GetBooks(Guid? typeId, Guid? subTypeId, Guid? authorId, string name = "")
        {
            var query = db.Books
                .Include(x => x.SubType).ThenInclude(x => x.Type)
                .Include(x => x.Author)
                .Where(x =>
                    (typeId == null || x.SubType.TypeId == typeId) &&
                    (subTypeId == null || x.SubTypeId == subTypeId) &&
                    (authorId == null || x.AuthorId == authorId) &&
                    (name == null || x.Name.Contains(name))).ToList();
            return query.Select(x => new BookListDto
            {
                Name = x.Name,
                pageCount = x.PageCount,
                AuthorName = x.Author.Name,
                TypeName = x.SubType.Type.Name,
                SubTypeName = x.SubType.Name
            }).ToList();

        }
        [HttpGet]
        public BookDto GetBook(Guid Id){
            return mapper.Map<BookDto, Book>(db.Books.Find(Id));
        }

        [HttpGet]
        public IList<BookListDto> GetBooksWithStoreProcedure(Guid? typeId, Guid? subTypeId, Guid? authorId, string name = "")
        {
            var typeIdString = typeId.HasValue ? "'"+typeId.ToString()+"'" : "NULL";
            var subTypeIdString = subTypeId.HasValue ? "'"+ subTypeId.ToString()+"'" : "NULL";
            var authorIdString = authorId.HasValue ? "'"+ authorId.ToString()+"'" : "NULL";
            var nameString = string.IsNullOrEmpty(name) ? "NULL" : "'" + name + "'";
            var data = db.BookInformations
                .FromSqlRaw($"EXECUTE [dbo].[BookSelectProcedure] " +
                $"{typeIdString}," +
                $"{subTypeIdString}," +
                $"{authorIdString}," +
                $"{nameString}").ToList();
            return mapper.Map<BookListDto, BookInformation>(data);
        }
    }
}
