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
    public class DeleteBookCommandHandler : ICommandRequestHandler<DeleteBookCommandRequest, DeleteBookCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public DeleteBookCommandHandler(IConfiguration configuration) => _configuration = configuration;
       
        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BookId", request.Id);
                await connection.ExecuteAsync("DeleteBooks", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new DeleteBookCommandResponse() { Success = true };                
            }
        }
    }
}
