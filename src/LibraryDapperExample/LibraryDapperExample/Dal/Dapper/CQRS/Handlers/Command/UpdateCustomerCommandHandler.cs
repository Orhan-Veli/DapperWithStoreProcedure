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
    public class UpdateCustomerCommandHandler : ICommandRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly IConfiguration _configuration;

        public UpdateCustomerCommandHandler(IConfiguration configuration) => _configuration = configuration;
       
        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection =new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) 
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id",request.Id);
                parameters.Add("@Name", request.Name);
                parameters.Add("@LastName",request.LastName);
                await connection.ExecuteAsync("UpdateCustomer", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new UpdateCustomerCommandResponse { Success = true };
            }
           
        }
    }
}
