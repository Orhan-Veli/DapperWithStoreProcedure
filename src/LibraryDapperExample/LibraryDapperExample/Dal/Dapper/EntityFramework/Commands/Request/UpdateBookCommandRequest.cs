using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request
{
    public class UpdateBookCommandRequest : ICommandRequest<UpdateBookCommandResponse>
    {
        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public Guid WriterId { get; set; }
    }
}
