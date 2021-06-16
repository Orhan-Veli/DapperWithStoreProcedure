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
    public interface ICategoryService
    {
        Task<IResult<CreateCategoryCommandResponse>> Create(CreateCategoryCommandRequest request);
        Task<IResult<UpdateCategoryCommandResponse>> Update(UpdateCategoryCommandRequest request);
        Task<IResult<DeleteCategoryCommandResponse>> Delete(DeleteCategoryCommandRequest request);
        Task<IResult<List<GetAllCategoryQueryResponse>>> GetAll(GetAllCategoryQueryRequest request);
    }
}
