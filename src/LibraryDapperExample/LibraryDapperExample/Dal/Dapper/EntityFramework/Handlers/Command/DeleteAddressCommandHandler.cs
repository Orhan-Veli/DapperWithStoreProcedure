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
    public class DeleteAddressCommandHandler : ICommandRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {
        private readonly IConfiguration _configuration;

        public DeleteAddressCommandHandler(IConfiguration configuration) => _configuration = configuration;
        
        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            { 
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CountryId", request.CountryId);
                parameters.Add("@StateId", request.StateId);
                parameters.Add("@CountyId", request.CountyId);
                parameters.Add("@DistrictId", request.DistrictId);                
                await connection.ExecuteAsync("DeleteAddress",parameters, commandType:CommandType.StoredProcedure);
                connection.Close();
                return new DeleteAddressCommandResponse { Success = true };
            }
        }
    }
}
