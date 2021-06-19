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
    public class GetManagerByIdQueryHandler : IQueryRequestHandler<GetManagerByIdQueryRequest, GetManagerByIdQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetManagerByIdQueryHandler(IConfiguration configuration) => _configuration = configuration;

        public async Task<GetManagerByIdQueryResponse> Handle(GetManagerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ManagerId", request.Id);
                var result = connection.Query<GetManagerByIdQueryResponse>("GetManager",parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return new GetManagerByIdQueryResponse { LastName = result.FirstOrDefault().LastName, LibraryName = result.FirstOrDefault().LibraryName, Name = result.FirstOrDefault().Name };
            }
        }
    }
}
