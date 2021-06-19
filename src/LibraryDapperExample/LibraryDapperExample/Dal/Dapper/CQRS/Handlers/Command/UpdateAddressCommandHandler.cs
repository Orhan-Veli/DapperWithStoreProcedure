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
    public class UpdateAddressCommandHandler : ICommandRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public UpdateAddressCommandHandler(IConfiguration configuration) => _configuration = configuration;      
        
        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@CountryId", request.CountryId);
                parameter.Add("@CountryName", request.CountryName);
                parameter.Add("@StateId", request.StateId);
                parameter.Add("@StateName", request.StateName);
                parameter.Add("@CountyId", request.CountryId);
                parameter.Add("@CountyName", request.CountyName);
                parameter.Add("@DistrictId", request.DistrictId);
                parameter.Add("@DistrictName", request.DistrictName);
                await connection.ExecuteAsync("UpdateAddress", parameter, commandType:CommandType.StoredProcedure);
                connection.Close();
                return new UpdateAddressCommandResponse { Success = true };
            }
        }
    }
}
