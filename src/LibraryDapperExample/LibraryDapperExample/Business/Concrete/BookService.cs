using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Constants;
using LibraryDapperExample.Dal.Dapper.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
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
        public async Task<IResult<CreateBookCommandResponse>> Create(CreateBookCommandRequest requestModel)
        {
            if (
               requestModel == null ||
               string.IsNullOrEmpty(requestModel.Name) ||
               requestModel.WriterId == Guid.Empty ||
               requestModel.CategoryIds.Count == 0 ||
               requestModel.LibraryIds.Count == 0
               ) return new Result<CreateBookCommandResponse>(false);
            await _mediator.Send(requestModel);
            return new Result<CreateBookCommandResponse>(true);
        }

        public async Task<IResult<DeleteBookCommandResponse>> Delete(DeleteBookCommandRequest requestModel)
        {
            if (requestModel.Id == Guid.Empty) return new Result<DeleteBookCommandResponse>(false);
            await _mediator.Send(requestModel);
            return new Result<DeleteBookCommandResponse>(true);
        }    

        public async Task<IResult<UpdateBookCommandResponse>> Update(UpdateBookCommandRequest requestModel)
        {
            if (
                requestModel == null ||
                requestModel.BookId== Guid.Empty ||
                string.IsNullOrEmpty(requestModel.BookName) &&
                requestModel.WriterId == Guid.Empty              
                ) return new Result<UpdateBookCommandResponse>(false);
            await _mediator.Send(requestModel);
            return new Result<UpdateBookCommandResponse>(true);
        }
    }
}
