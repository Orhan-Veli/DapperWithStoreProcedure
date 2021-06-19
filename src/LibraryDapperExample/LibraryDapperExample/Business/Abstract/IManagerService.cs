using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Business.Abstract
{
    public interface IManagerService
    {
        Task<IResult<CreateManagerCommandResponse>> Create(CreateManagerCommandRequest request);
        Task<IResult<UpdateManagerCommandResponse>> Update(UpdateManagerCommandRequest request);
        Task<IResult<DeleteManagerCommandResponse>> Delete(DeleteManagerCommandRequest request);

    }
}
