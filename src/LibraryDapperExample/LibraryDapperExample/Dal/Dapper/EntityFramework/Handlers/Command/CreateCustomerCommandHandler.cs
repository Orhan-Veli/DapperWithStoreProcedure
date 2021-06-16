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
    public class CreateCustomerCommandHandler : ICommandRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public CreateCustomerCommandHandler(IConfiguration configuration) => _configuration = configuration;
        
        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name",request.Name);
                parameters.Add("@LastName",request.LastName);
                parameters.Add("@AddressId",request.AddressId);
                parameters.Add("@LibrariessId", request.LibraryIds);
                await connection.ExecuteAsync("CreateCustomer", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return new CreateCustomerCommandResponse { Success = true };                
            }
        }
    }
}
