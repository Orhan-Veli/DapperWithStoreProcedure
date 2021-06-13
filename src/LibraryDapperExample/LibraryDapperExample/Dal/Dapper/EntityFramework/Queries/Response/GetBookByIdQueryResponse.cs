using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response
{
    public class GetBookByIdQueryResponse
    {
        public string bookname { get; set; }

        public string writername { get; set; }

        public string writerlastname { get; set; }

        public string categoryname { get; set; }
    }
}
