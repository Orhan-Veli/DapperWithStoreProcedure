using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response
{
    public class GetCustomerByIdQueryResponse
    {
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string LibraryName { get; set; }
    }
}
