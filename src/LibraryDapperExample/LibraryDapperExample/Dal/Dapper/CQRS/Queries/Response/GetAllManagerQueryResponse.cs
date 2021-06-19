using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response
{
    public class GetAllManagerQueryResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LibraryName { get; set; }
    }
}
