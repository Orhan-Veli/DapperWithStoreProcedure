using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response
{
    public class GetAllCategoryQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
