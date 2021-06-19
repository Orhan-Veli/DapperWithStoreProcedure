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
    public class GetAllManagerQueryHandler : IQueryRequestHandler<GetAllManagerQueryRequest, List<GetAllManagerQueryResponse>>
    {
        private readonly IConfiguration _configuration;
        public GetAllManagerQueryHandler(IConfiguration configuration) => _configuration = configuration;
        
        public async Task<List<GetAllManagerQueryResponse>> Handle(GetAllManagerQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnetion")))
            {
                connection.Open();
                DynamicParameters paramaters = new DynamicParameters();
                var result = connection.Query<GetAllManagerQueryResponse>("GetManager", paramaters, commandType: CommandType.StoredProcedure).ToList();
                connection.Close();
                return result;
            }
        }
    }
}
