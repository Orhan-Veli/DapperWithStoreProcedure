using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
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

        public async Task<IResult<DeleteManagerCommandResponse>> Delete(DeleteManagerCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty) return new Result<DeleteManagerCommandResponse>(false);
            var result = await _mediator.Send(request);
            if(!result.Success) return new Result<DeleteManagerCommandResponse>(false);
            return new Result<DeleteManagerCommandResponse>(true);
        }

        public async Task<IResult<GetManagerByIdQueryResponse>> Get(GetManagerByIdQueryRequest request)
        {
            if (request == null || request.Id == Guid.Empty) return new Result<GetManagerByIdQueryResponse>(false);
            var result = await _mediator.Send(request);
            if(result == null || string.IsNullOrEmpty(result.LastName) || string.IsNullOrEmpty(result.LibraryName) || string.IsNullOrEmpty(result.Name)) return new Result<GetManagerByIdQueryResponse>(false);
            return new Result<GetManagerByIdQueryResponse>(true, result);
        }

        public async Task<IResult<UpdateManagerCommandResponse>> Update(UpdateManagerCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty || request.LibraryId == Guid.Empty || string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.Name))
                return new Result<UpdateManagerCommandResponse>(false);
            var result = await _mediator.Send(request);
            if(!result.Success) return new Result<UpdateManagerCommandResponse>(false);
            return new Result<UpdateManagerCommandResponse>(true);
        }
        public async Task<IResult<List<GetAllManagerQueryResponse>>> GetAll(GetAllManagerQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return new Result<List<GetAllManagerQueryResponse>>(true,result);
        }
    }
}
