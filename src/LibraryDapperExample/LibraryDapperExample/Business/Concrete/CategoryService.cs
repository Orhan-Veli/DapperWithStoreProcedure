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
    public class CategoryService : ICategoryService
    {
        private readonly Mediator _mediator;
        public CategoryService(Mediator mediator) => _mediator = mediator;
        
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

        public async Task<IResult<UpdateCategoryCommandResponse>> Update(UpdateCategoryCommandRequest request)
        {
            if (request == null || request.Id == Guid.Empty || string.IsNullOrEmpty(request.Name)) return new Result<UpdateCategoryCommandResponse>(false);
            await _mediator.Send(request);
            return new Result<UpdateCategoryCommandResponse>(true);
        }
    }
}
