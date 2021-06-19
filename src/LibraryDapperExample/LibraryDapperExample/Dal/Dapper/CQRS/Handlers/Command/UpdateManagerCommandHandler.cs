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
    public class UpdateManagerCommandHandler : ICommandRequestHandler<UpdateManagerCommandRequest, UpdateManagerCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public UpdateManagerCommandHandler(IConfiguration configuration) => _configuration = configuration;

        public async Task<UpdateManagerCommandResponse> Handle(UpdateManagerCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add("@Id",request.Id);
                paramaters.Add("@Name",request.Name);
                paramaters.Add("@LastName",request.LastName);
                paramaters.Add("@LibraryId",request.LibraryId);
                await connection.ExecuteAsync("UpdateCustomer", paramaters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new UpdateManagerCommandResponse { Success = true };

            }
        }
    }
}
