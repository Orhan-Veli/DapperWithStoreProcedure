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
    public class GetLibraryByIdQueryHandler : IQueryRequestHandler<GetLibraryByIdQueryRequest, GetLibraryByIdQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetLibraryByIdQueryHandler(IConfiguration configuration) => _configuration = configuration;
            
        public async Task<GetLibraryByIdQueryResponse> Handle(GetLibraryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add("@LibraryId",request.Id);
                var result = connection.Query<GetLibraryByIdQueryResponse>("GetLibraries",paramaters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return new GetLibraryByIdQueryResponse {Name = result.FirstOrDefault().Name };
            }
        }
    }
}
