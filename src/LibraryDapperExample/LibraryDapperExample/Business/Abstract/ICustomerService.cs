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
    public interface ICustomerService
    {
        Task<IResult<CreateCustomerCommandResponse>> Create(CreateCustomerCommandRequest request);
        Task<IResult<DeleteCustomerCommandResponse>> Delete(DeleteCustomerCommandRequest response);
        Task<IResult<UpdateCustomerCommandResponse>> Update(UpdateCustomerCommandRequest response);
        Task<IResult<GetCustomerByIdQueryResponse>> Get(GetCustomerByIdQueryRequest response);
        Task<IResult<List<GetAllCustomerQueryResponse>>> GetAll(GetAllCustomerQueryRequest response);
    }
}
