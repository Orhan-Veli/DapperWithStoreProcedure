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
    public class WriterService : IWriterService
    {
        private readonly IMediator _mediator;
        public WriterService(IMediator mediator) => _mediator = mediator;
        public async Task<IResult<CreateWriterCommandResponse>> Create(CreateWriterCommandRequest request)
        {
            if (request == null || request.AddressId == Guid.Empty || string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.Name))
                return new Result<CreateWriterCommandResponse>(false);
            var result = _mediator.Send(request);
            if(result.IsFaulted) return new Result<CreateWriterCommandResponse>(false);
            return new Result<CreateWriterCommandResponse>(true);
        }

        public async Task<IResult<DeleteWriterCommandResponse>> Delete(DeleteWriterCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty) return new Result<DeleteWriterCommandResponse>(false);
           var result = await _mediator.Send(request);
            if(!result.Success) return new Result<DeleteWriterCommandResponse>(false);
            return new Result<DeleteWriterCommandResponse>(true);
        }

        public async Task<IResult<GetWriterByIdQueryResponse>> Get(GetWriterByIdQueryRequest request)
        {
            if (request == null || request.Id == Guid.Empty) return new Result<GetWriterByIdQueryResponse>(false);
            var result = await _mediator.Send(request);
            return new Result<GetWriterByIdQueryResponse>(true,result);
        }

        public async Task<IResult<List<GetAllWriterQueryResponse>>> GetAll(GetAllWriterQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return new Result<List<GetAllWriterQueryResponse>>(true, result);

        }

        public async Task<IResult<UpdateWriterCommandResponse>> Update(UpdateWriterCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty || string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.Name))
                return new Result<UpdateWriterCommandResponse>(false);
            var result = await _mediator.Send(request);
            if(!result.Success) return new Result<UpdateWriterCommandResponse>(false);
            return new Result<UpdateWriterCommandResponse>(true);
        }
    }
}
