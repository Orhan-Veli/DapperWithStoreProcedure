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
    public class CustomerService : ICustomerService
    {
        private readonly IMediator _mediator;

        public CustomerService(IMediator mediator) => _mediator = mediator;

        public async Task<IResult<CreateCustomerCommandResponse>> Create(CreateCustomerCommandRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) &&
                string.IsNullOrEmpty(request.LastName) &&
                request.AddressId == Guid.Empty) return new Result<CreateCustomerCommandResponse>(false);
           var result = await _mediator.Send(request);
            if(!result.Success) return new Result<CreateCustomerCommandResponse>(false);
            return new Result<CreateCustomerCommandResponse>(true);
                
        }

        public async Task<IResult<DeleteCustomerCommandResponse>> Delete(DeleteCustomerCommandRequest response)
        {
            if (response == null || response.Id == Guid.Empty) return new Result<DeleteCustomerCommandResponse>(false);
            var result = await _mediator.Send(response);
           if(!result.Success) return new Result<DeleteCustomerCommandResponse>(false);
            return new Result<DeleteCustomerCommandResponse>(true);
        }

        public async Task<IResult<GetCustomerByIdQueryResponse>> Get(GetCustomerByIdQueryRequest response)
        {
            if (response == null || response.Id == Guid.Empty) return new Result<GetCustomerByIdQueryResponse>(false);
            var result = await _mediator.Send(response);
            if(result == null || string.IsNullOrEmpty(result.CustomerLastName) || string.IsNullOrEmpty(result.CustomerName) || string.IsNullOrEmpty(result.LibraryName)) return new Result<GetCustomerByIdQueryResponse>(false);
            return new Result<GetCustomerByIdQueryResponse>(true,result);
        }

        public async Task<IResult<List<GetAllCustomerQueryResponse>>> GetAll(GetAllCustomerQueryRequest response)
        {
            var result = await _mediator.Send(response);
            return new Result<List<GetAllCustomerQueryResponse>>(true,result);
        }

        public async Task<IResult<UpdateCustomerCommandResponse>> Update(UpdateCustomerCommandRequest response)
        {
            if (response == null || response.Id == Guid.Empty || string.IsNullOrEmpty(response.LastName) || string.IsNullOrEmpty(response.Name)) return new Result<UpdateCustomerCommandResponse>(false);
            var result = await _mediator.Send(response);
            if(!result.Success) return new Result<UpdateCustomerCommandResponse>(false);
            return new Result<UpdateCustomerCommandResponse>(true);

        }
    }
}
