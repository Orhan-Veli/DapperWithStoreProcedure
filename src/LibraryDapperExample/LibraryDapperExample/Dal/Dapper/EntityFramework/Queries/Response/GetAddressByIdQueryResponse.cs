using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response
{
    public class GetAddressByIdQueryResponse
    {
        public string CountryName { get; set; }
        public string CountyName { get; set; }
        public string DistrictName { get; set; }
        public string StateName { get; set; }

    }
}
