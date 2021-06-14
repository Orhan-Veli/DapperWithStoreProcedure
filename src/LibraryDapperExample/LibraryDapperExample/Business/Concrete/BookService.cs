using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Constants;
using LibraryDapperExample.Dal.Dapper.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using LibraryDapperExample.Dal.Entity;
using LibraryDapperExample.Utilities.Abstract;
using LibraryDapperExample.Utilities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Business.Concrete
{
    public class BookService : IBookService
    {
        private readonly IMediator _mediator;
        public BookService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult<List<GetAllBookQueryResponse>>> GetAll(GetAllBookQueryRequest requestModel)
        {
            var allBooks = await _mediator.Send(requestModel);
            return new Result<List<GetAllBookQueryResponse>>(true,allBooks);
        }

        public async Task<IResult<GetBookByIdQueryResponse>> GetById(GetByBookIdQueryRequest requestModel)
        {
            if (requestModel.Id == Guid.Empty) return new Result<GetBookByIdQueryResponse>(false);
            var book = await _mediator.Send(requestModel);
            return new Result<GetBookByIdQueryResponse>(true,book);
        }
        public async Task<IResult<object>> Create(CreateBookCommandRequest requestModel)
        {
            if (
               requestModel == null ||
               string.IsNullOrEmpty(requestModel.Name) ||
               requestModel.WriterId == Guid.Empty ||
               requestModel.CategoryIds.Count == 0 ||
               requestModel.LibraryIds.Count == 0
               ) return new Result<object>(false, Messages.ModelNotValid);
            await _mediator.Send(requestModel);
            return new Result<object>(true);
        }

        public async Task<IResult<bool>> Delete(DeleteBookCommandRequest requestModel)
        {
            if (requestModel.Id == Guid.Empty) return new Result<bool>(false);
            await _mediator.Send(requestModel);
            return new Result<bool>(true);
        }

        //public async Task<IResult<Book>> Get(Guid id)
        //{
        //    if (id == Guid.Empty) return new Result<Book>(Messages.IdIsNotValid, false);
        //    var result = await _entity.Get(id);
        //    if (!result.Success || result.Data == null) return new Result<Book>(false);
        //    return new Result<Book>(true,result.Data);
        //}


        //public async Task<IResult<object>> Update(Book model)
        //{
        //    if (
        //        model == null ||
        //        model.Id == Guid.Empty ||
        //        string.IsNullOrEmpty(model.Name) ||
        //        model.WriterId == Guid.Empty ||
        //        model.CategoryIds.Count == 0 ||
        //        model.LibraryIds.Count == 0
        //        ) return new Result<object>(false, Messages.ModelNotValid);
        //    await _entity.Update(model);
        //    return new Result<object>(true);
        //}
    }
}
