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
    public class GetBookByIdQueryHandler : IQueryRequestHandler<GetByBookIdQueryRequest, GetBookByIdQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetBookByIdQueryHandler(IConfiguration configuration) => _configuration = configuration;
      
        public async Task<GetBookByIdQueryResponse> Handle(GetByBookIdQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);
                GetBookByIdQueryResponse book = connection.Query<GetBookByIdQueryResponse>("GetBook", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                connection.Close();
                return book;
            }
        }
    }
}
