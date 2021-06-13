﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Core
{
    public interface ICommandRequest<TResponse> : IRequest<TResponse>
    {
    }
}
