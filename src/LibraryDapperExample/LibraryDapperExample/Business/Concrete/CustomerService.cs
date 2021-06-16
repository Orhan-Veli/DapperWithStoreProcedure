using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
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
        private readonly Mediator _mediator;

        public CustomerService(Mediator mediator) => _mediator = mediator;

        public async Task<IResult<CreateCustomerCommandResponse>> Create(CreateCustomerCommandRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) &&
                string.IsNullOrEmpty(request.LastName) &&
                request.AddressId == Guid.Empty) return new Result<CreateCustomerCommandResponse>(false);
           var result = await _mediator.Send(request);
            if(!result.Success) return new Result<CreateCustomerCommandResponse>(false);
            return new Result<CreateCustomerCommandResponse>(true);
                
        }
    }
}
