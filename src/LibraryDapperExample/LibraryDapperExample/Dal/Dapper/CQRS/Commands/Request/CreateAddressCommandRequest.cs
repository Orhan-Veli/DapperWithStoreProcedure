using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request
{
    public class CreateAddressCommandRequest : ICommandRequest<CreateAddressCommandResponse>
    {
        public string CountryName { get; set; }

        public string StateName { get; set; }

        public string CountyName { get; set; }

        public string DistrictName { get; set; }
    }
}
