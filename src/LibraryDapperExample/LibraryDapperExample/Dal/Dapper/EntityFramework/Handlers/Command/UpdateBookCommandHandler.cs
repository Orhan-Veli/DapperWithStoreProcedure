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
    public class UpdateBookCommandHandler : ICommandRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public UpdateBookCommandHandler(IConfiguration configuration) => _configuration = configuration;
       
        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BookId", request.BookId);
                parameters.Add("@BookName", request.BookName);
                parameters.Add("@WriterId", request.WriterId);
                var result = await connection.ExecuteAsync("UpdateBook", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new UpdateBookCommandResponse { Success = true };                
            }
        }
    }
}
