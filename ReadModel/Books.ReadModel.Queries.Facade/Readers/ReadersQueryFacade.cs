using Books.ReadModel.Context.Models;
using Books.ReadModel.Queries.Contracts.Readers;
using Books.ReadModel.Queries.Contracts.Readers.DataContracts;
using Framework.Core.Mapper;
using Framework.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.ReadModel.Queries.Facade.Readers
{
    [Route("library/api/Readers/[action]")]
    [ApiController]
    public class ReadersQueryFacade : FacadeQueryBase, IReaderQueryFacade
    {
        private readonly LibraryContext _db;
        private readonly IMapper _mapper;

        public ReadersQueryFacade(LibraryContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public IList<ReaderListDto> GetReaders()
        {
            return _mapper.Map<ReaderListDto,Reader>(_db.Readers.ToList());
        }
    }
}
