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
    public class DeleteLibraryCommandHandler : ICommandRequestHandler<DeleteLibraryCommandRequest, DeleteLibraryCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public DeleteLibraryCommandHandler(IConfiguration configuration) => _configuration = configuration;
        
        public async Task<DeleteLibraryCommandResponse> Handle(DeleteLibraryCommandRequest request, CancellationToken cancellationToken)
        {            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add("@LibraryId",request.Id);
                await connection.ExecuteAsync("DeleteLibrary",paramaters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new DeleteLibraryCommandResponse { Success = true };
            }
        }
    }
}
