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
    public interface IAddressService
    {
    
        Task<IResult<CreateAddressCommandResponse>> Create(CreateAddressCommandRequest requestModel);

        Task<IResult<UpdateAddressCommandResponse>> Update(UpdateAddressCommandRequest requestModel);

        Task<IResult<DeleteAddressCommandResponse>> Delete(DeleteAddressCommandRequest requestModel);

        Task<IResult<List<GetAllAddressQueryResponse>>> GetAll(GetAllAddressQueryRequest requestModel);

        Task<IResult<GetAddressByIdQueryResponse>> Get(GetAddressByIdQueryRequest requestModel);
    }
}
