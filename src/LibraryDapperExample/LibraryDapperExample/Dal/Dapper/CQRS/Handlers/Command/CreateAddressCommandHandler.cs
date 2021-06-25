using Dapper;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.EntityFramework.Handlers.Command
{
    public class CreateAddressCommandHandler : ICommandRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public CreateAddressCommandHandler(IConfiguration configuration) => _configuration = configuration;
        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {                
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CountryName", request.CountryName);
                parameters.Add("@StateName", request.StateName);
                parameters.Add("@CountyName", request.CountyName);
                parameters.Add("@DistrictName", request.DistrictName);
                connection.Open();
                await connection.QueryAsync("CreateAddress",parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return new CreateAddressCommandResponse { Success = true };
            }            
        }
    }
}
