using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request
{
    public class DeleteLibraryCommandRequest : ICommandRequest<DeleteLibraryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
