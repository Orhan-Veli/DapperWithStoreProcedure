using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using LibraryDapperExample.Dal.Entity;
using LibraryDapperExample.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Business.Abstract
{
    public interface IBookService
    {
        
        Task<IResult<List<GetAllBookQueryResponse>>> GetAll(GetAllBookQueryRequest requestModel);

        Task<IResult<GetBookByIdQueryResponse>> GetById(GetByBookIdQueryRequest requestModel);
    }
}
