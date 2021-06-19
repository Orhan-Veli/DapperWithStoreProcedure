using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Utilities.Abstract;
using LibraryDapperExample.Utilities.Concrete;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Business.Concrete
{
    public class ManagerService : IManagerService
    {
        private readonly IMediator _mediator;

        public ManagerService(IMediator mediator) => _mediator = mediator;
            
        public async Task<IResult<CreateManagerCommandResponse>> Create(CreateManagerCommandRequest request)
        {
            if (request == null || request.AddressId == Guid.Empty || request.LibraryId == Guid.Empty || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.LastName))
                return new Result<CreateManagerCommandResponse>(false);
            var result = await _mediator.Send(request);
            if(!result.Success) return new Result<CreateManagerCommandResponse>(false);
            return new Result<CreateManagerCommandResponse>(true);
        }
    }
}
