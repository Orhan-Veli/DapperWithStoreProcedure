using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request
{
    public class GetAddressByIdQueryRequest : IQueryRequest<GetAddressByIdQueryResponse>
    {
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public Guid CountyId { get; set; }
        public Guid DistrictId { get; set; }
    }
}
