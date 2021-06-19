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
    public class DeleteWriterCommandHandler : ICommandRequestHandler<DeleteWriterCommandRequest, DeleteWriterCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public DeleteWriterCommandHandler(IConfiguration configuration) => _configuration = configuration;
        
        public async Task<DeleteWriterCommandResponse> Handle(DeleteWriterCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add("@WriterId", request.Id);
                await connection.ExecuteAsync("DeleteWriter", paramaters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new DeleteWriterCommandResponse { Success = true };
            }         
        }
    }
}
