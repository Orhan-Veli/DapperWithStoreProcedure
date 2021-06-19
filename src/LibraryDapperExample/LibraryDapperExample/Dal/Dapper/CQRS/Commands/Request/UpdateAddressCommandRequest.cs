using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request
{
    public class UpdateAddressCommandRequest : ICommandRequest<UpdateAddressCommandResponse>
    {
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public Guid StateId { get; set; }
        public string StateName { get; set; }
        public Guid CountyId { get; set; }
        public string CountyName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }

    }
}
