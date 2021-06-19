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
    public class GetWriterByIdQueryHandler : IQueryRequestHandler<GetWriterByIdQueryRequest, GetWriterByIdQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetWriterByIdQueryHandler(IConfiguration configuration) => _configuration = configuration;
        public async Task<GetWriterByIdQueryResponse> Handle(GetWriterByIdQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@WriterId",request.Id);
                var result = await connection.QueryAsync<GetWriterByIdQueryResponse>("GetWriter",parameters,commandType: CommandType.StoredProcedure);
                connection.Close();
                return new GetWriterByIdQueryResponse {AddressId = result.FirstOrDefault().AddressId, Id= result.FirstOrDefault().Id,LastName = result.FirstOrDefault().LastName,Name = result.FirstOrDefault().Name};
            }
        }
    }
}
