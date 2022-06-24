using Books.ReadModel.Queries.Contracts.Readers.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ReadModel.Queries.Contracts.Readers
{
    public interface IReaderQueryFacade
    {
        IList<ReaderListDto> GetReaders();
    }
}
