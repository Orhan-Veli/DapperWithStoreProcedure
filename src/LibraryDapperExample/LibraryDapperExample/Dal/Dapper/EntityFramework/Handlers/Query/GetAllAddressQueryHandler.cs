using Dapper;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Handlers.Query
{
    public class GetAllAddressQueryHandler : IQueryRequestHandler<GetAllAddressQueryRequest, List<GetAllAddressQueryResponse>>
    {
        private readonly IConfiguration _configuration;
        public GetAllAddressQueryHandler(IConfiguration configuration) => _configuration = configuration;

        public async Task<List<GetAllAddressQueryResponse>> Handle(GetAllAddressQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {                
                DynamicParameters parameters = new DynamicParameters();
                connection.Open();
                parameters.Add("@CountryId",null);
                parameters.Add("@CountyId",null);
                parameters.Add("@DistrictId",null);
                parameters.Add("@StateId",null);
                var result = connection.Query<GetAllAddressQueryResponse>("GetAddress",parameters,commandType:CommandType.StoredProcedure).ToList();
                connection.Close();
                return new List<GetAllAddressQueryResponse>(result);
            }
        }
    }
}
