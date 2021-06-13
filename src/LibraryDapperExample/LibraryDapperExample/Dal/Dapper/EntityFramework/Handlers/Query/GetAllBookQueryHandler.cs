using Dapper;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Handlers.Query
{
    public class GetAllBookQueryHandler : IQueryRequestHandler<GetAllBookQueryRequest,List<GetAllBookQueryResponse>>
    {
        private readonly IConfiguration _configuration;
        public GetAllBookQueryHandler(IConfiguration configuration) => _configuration = configuration;

        public async Task<List<GetAllBookQueryResponse>> Handle(GetAllBookQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", null);
                var book = connection.Query<GetAllBookQueryResponse>("GetBook", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                connection.Close();
                return book;
            }
        }
    }
}
