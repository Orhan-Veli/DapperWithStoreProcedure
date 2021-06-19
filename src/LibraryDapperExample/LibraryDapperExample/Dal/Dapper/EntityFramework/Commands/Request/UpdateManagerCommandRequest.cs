using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request
{
    public class UpdateManagerCommandRequest : ICommandRequest<UpdateManagerCommandResponse>
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public Guid LibraryId { get; set; }
    }
}
