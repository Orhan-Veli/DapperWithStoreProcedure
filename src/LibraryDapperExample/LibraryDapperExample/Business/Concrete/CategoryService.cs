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
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;
        public CategoryService(IMediator mediator) => _mediator = mediator;
        
        public async Task<IResult<CreateCategoryCommandResponse>> Create(CreateCategoryCommandRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name)) return new Result<CreateCategoryCommandResponse>(false);
            await _mediator.Send(request);
            return new Result<CreateCategoryCommandResponse>(true);
        }

        public async Task<IResult<DeleteCategoryCommandResponse>> Delete(DeleteCategoryCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty) return new Result<DeleteCategoryCommandResponse>(false);
            await _mediator.Send(request);
            return new Result<DeleteCategoryCommandResponse>(true);
        }

        public async Task<IResult<GetCategoryByIdQueryResponse>> Get(GetCategoryByIdQueryRequest request)
        {
            if (request.Id == Guid.Empty) return new Result<GetCategoryByIdQueryResponse>(false);
            var result = await _mediator.Send(request);
            if (result == null) return new Result<GetCategoryByIdQueryResponse>(false);
            return new Result<GetCategoryByIdQueryResponse>(true,result);
        }

        public async Task<IResult<List<GetAllCategoryQueryResponse>>> GetAll(GetAllCategoryQueryRequest request)
        {
          var result = await _mediator.Send(request);
            if (result == null || result.Count == 0) return new Result<List<GetAllCategoryQueryResponse>>(false);
            return new Result<List<GetAllCategoryQueryResponse>>(true,result);
        }

        public async Task<IResult<UpdateCategoryCommandResponse>> Update(UpdateCategoryCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty || string.IsNullOrEmpty(request.Name)) return new Result<UpdateCategoryCommandResponse>(false);
            await _mediator.Send(request);
            return new Result<UpdateCategoryCommandResponse>(true);
        }
    }
}
