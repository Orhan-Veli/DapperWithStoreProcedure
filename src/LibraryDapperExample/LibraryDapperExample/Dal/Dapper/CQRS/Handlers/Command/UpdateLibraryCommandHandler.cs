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
    public class UpdateLibraryCommandHandler : ICommandRequestHandler<UpdateLibraryCommandRequest, UpdateLibraryCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public UpdateLibraryCommandHandler(IConfiguration configuration) => _configuration = configuration;


        public async Task<UpdateLibraryCommandResponse> Handle(UpdateLibraryCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add("@Id",request.Id);
                paramaters.Add("@Name",request.Name);
                await connection.ExecuteAsync("UpdateLibrary", paramaters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new UpdateLibraryCommandResponse { Success = true };
            }
        }
    }
}
