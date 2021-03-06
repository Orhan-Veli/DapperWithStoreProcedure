using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using LibraryDapperExample.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Business.Abstract
{
    public interface ILibraryService
    {
        Task<IResult<CreateLibraryCommandResponse>> Create(CreateLibraryCommandRequest request);
        Task<IResult<DeleteLibraryCommandResponse>> Delete(DeleteLibraryCommandRequest request);
        Task<IResult<UpdateLibraryCommandResponse>> Update(UpdateLibraryCommandRequest request);
        Task<IResult<GetLibraryByIdQueryResponse>> Get(GetLibraryByIdQueryRequest request);
        Task<IResult<List<GetAllLibraryQueryResponse>>> GetAll(GetAllLibraryQueryRequest request);
    }
}
