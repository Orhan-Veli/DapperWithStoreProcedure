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
    public class GetCustomerByIdQueryHandler : IQueryRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetCustomerByIdQueryHandler(IConfiguration configuration) => _configuration = configuration;

        
        public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId",request.Id);
                var result = connection.Query<GetCustomerByIdQueryResponse>("GetCustomer", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new GetCustomerByIdQueryResponse {CustomerLastName = result.FirstOrDefault().CustomerLastName, CustomerName = result.FirstOrDefault().CustomerName, LibraryName = result.FirstOrDefault().LibraryName };
            }
        }
    }
}
