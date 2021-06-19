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
    public class GetAllLibraryQueryHandler : IQueryRequestHandler<GetAllLibraryQueryRequest, List<GetAllLibraryQueryResponse>>
    {
        private readonly IConfiguration _configuration;
        public GetAllLibraryQueryHandler(IConfiguration configuration) => _configuration = configuration;
        
        public async Task<List<GetAllLibraryQueryResponse>> Handle(GetAllLibraryQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                var result =  connection.Query<GetAllLibraryQueryResponse>("GetLibraries", parameters, commandType: CommandType.StoredProcedure).ToList();
                connection.Close();
                return result;
            }
        }
    }
}
