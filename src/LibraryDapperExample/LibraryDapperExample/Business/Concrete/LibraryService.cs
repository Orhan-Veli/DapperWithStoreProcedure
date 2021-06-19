using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using LibraryDapperExample.Utilities.Abstract;
using LibraryDapperExample.Utilities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Business.Concrete
{
    public class LibraryService : ILibraryService
    {
        private readonly Mediator _mediator;
        public LibraryService(Mediator mediator) => _mediator = mediator;
        public async Task<IResult<CreateLibraryCommandResponse>> Create(CreateLibraryCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty || string.IsNullOrEmpty(request.Name)) return new Result<CreateLibraryCommandResponse>(false);
          var result = await _mediator.Send(request);
            if(!result.Success) return new Result<CreateLibraryCommandResponse>(false);
            return new Result<CreateLibraryCommandResponse>(true);
        }

        public async Task<IResult<DeleteLibraryCommandResponse>> Delete(DeleteLibraryCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty) return new Result<DeleteLibraryCommandResponse>(false);
            var result = await _mediator.Send(request);
            if(!result.Success) return new Result<DeleteLibraryCommandResponse>(false);
            return new Result<DeleteLibraryCommandResponse>(true);
        }

        public async Task<IResult<GetLibraryByIdQueryResponse>> Get(GetLibraryByIdQueryRequest request)
        {
            if (request == null || request.Id == Guid.Empty) return new Result<GetLibraryByIdQueryResponse>(false);
            var result = await _mediator.Send(request);
            if (result == null || string.IsNullOrEmpty(result.Name)) return new Result<GetLibraryByIdQueryResponse>(false);
            return new Result<GetLibraryByIdQueryResponse>(true);
        }

        public async Task<IResult<List<GetAllLibraryQueryResponse>>> GetAll(GetAllLibraryQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return new Result<List<GetAllLibraryQueryResponse>> (true, result);
        }

        public async Task<IResult<UpdateLibraryCommandResponse>> Update(UpdateLibraryCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty || string.IsNullOrEmpty(request.Name)) return new Result<UpdateLibraryCommandResponse>(false);
            var result = await _mediator.Send(request);
            if(!result.Success) return new Result<UpdateLibraryCommandResponse>(false);
            return new Result<UpdateLibraryCommandResponse>(true);
        }
    }
}
