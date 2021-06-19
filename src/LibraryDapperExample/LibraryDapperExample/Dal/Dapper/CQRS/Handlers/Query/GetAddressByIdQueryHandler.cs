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
    public class GetAddressByIdQueryHandler : IQueryRequestHandler<GetAddressByIdQueryRequest, GetAddressByIdQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetAddressByIdQueryHandler(IConfiguration configuration) => _configuration = configuration;

        public async Task<GetAddressByIdQueryResponse> Handle(GetAddressByIdQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CountryId",request.CountryId);
                parameters.Add("@CountyId",request.CountyId);
                parameters.Add("@DistrictId",request.DistrictId);
                parameters.Add("@StateId",request.StateId);
                var result = connection.Query<GetAddressByIdQueryResponse>("GetBook", parameters, commandType: CommandType.StoredProcedure).ToList();
                connection.Close();
                return new GetAddressByIdQueryResponse() { CountryName = result.FirstOrDefault().CountryName, CountyName = result.FirstOrDefault().CountyName, DistrictName = result.FirstOrDefault().DistrictName, StateName = result.FirstOrDefault().StateName };
            }
        }
    }
}
