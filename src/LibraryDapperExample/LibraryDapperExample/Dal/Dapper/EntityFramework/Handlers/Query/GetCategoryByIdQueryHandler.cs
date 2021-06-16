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
    public class GetCategoryByIdQueryHandler : IQueryRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetCategoryByIdQueryHandler(IConfiguration configuration) => _configuration = configuration;       
        
        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CategoryId",request.Id);
                var category = await connection.QueryAsync<GetCategoryByIdQueryResponse>("GetCategory",parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return new GetCategoryByIdQueryResponse { Name = category.FirstOrDefault().Name };
            }
        }
    }
}
