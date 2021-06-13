using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using LibraryDapperExample.Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request
{
    public class CreateBookCommandRequest : ICommandRequest<CreateBookCommandResponse>
    {
        public string Name { get; set; }
        public Guid WriterId { get; set; }
        public List<Guid> CategoryIds { get; set; }
        
        public List<Guid> LibraryIds { get; set; }
    }
}
