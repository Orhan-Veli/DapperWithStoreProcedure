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
    public class CreateLibraryCommandHandler : ICommandRequestHandler<CreateLibraryCommandRequest, CreateLibraryCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public CreateLibraryCommandHandler(IConfiguration configuration) => _configuration = configuration;

        public async Task<CreateLibraryCommandResponse> Handle(CreateLibraryCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", request.Name);
                parameters.Add("@AddressId", request.Id);
                await connection.ExecuteAsync("CreateLibraries", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new CreateLibraryCommandResponse { Success = true };
            }
        }
    }
}
