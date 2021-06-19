using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
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
    }
}
