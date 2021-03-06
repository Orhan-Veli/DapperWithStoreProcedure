using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request
{
    public class GetManagerByIdQueryRequest : IQueryRequest<GetManagerByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
