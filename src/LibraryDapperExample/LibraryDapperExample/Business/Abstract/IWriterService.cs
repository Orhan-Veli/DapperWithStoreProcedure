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
    public interface IWriterService
    {
        Task<IResult<CreateWriterCommandResponse>> Create(CreateWriterCommandRequest request);
        Task<IResult<UpdateWriterCommandResponse>> Update(UpdateWriterCommandRequest request);
        Task<IResult<DeleteWriterCommandResponse>> Delete(DeleteWriterCommandRequest request);
        Task<IResult<GetWriterByIdQueryResponse>> Get(GetWriterByIdQueryRequest request);
        Task<IResult<List<GetAllWriterQueryResponse>>> GetAll(GetAllWriterQueryRequest request);
    }
}
