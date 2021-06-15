using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request
{
    public class DeleteAddressCommandRequest : ICommandRequest<DeleteAddressCommandResponse>
    {
        public Guid CountryId { get; set; }

        public Guid StateId { get; set; }

        public Guid CountyId { get; set; }

        public Guid DistrictId { get; set; }
    }
}
