﻿using LibraryDapperExample.Business.Abstract;
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
    }
}