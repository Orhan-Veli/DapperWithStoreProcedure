using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request
{
    public class CreateManagerCommandRequest : ICommandRequest<CreateManagerCommandResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Guid LibraryId { get; set; }
        public Guid AddressId { get; set; }

    }
}
