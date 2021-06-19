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
    public class GetAllWriterQueryHandler : IQueryRequestHandler<GetAllWriterQueryRequest, List<GetAllWriterQueryResponse>>
    {
        private readonly IConfiguration _configruation;
        public GetAllWriterQueryHandler(IConfiguration configruation) => _configruation = configruation;
        
        public async Task<List<GetAllWriterQueryResponse>> Handle(GetAllWriterQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configruation.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                 var result = connection.Query<GetAllWriterQueryResponse>("GetWriter", parameters, commandType: CommandType.StoredProcedure).ToList();
                connection.Close();
                return result;

            }
        }
    }
}
