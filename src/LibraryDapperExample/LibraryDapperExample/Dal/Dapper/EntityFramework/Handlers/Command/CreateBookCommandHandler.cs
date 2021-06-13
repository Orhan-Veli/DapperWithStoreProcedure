using Dapper;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Core;
using LibraryDapperExample.Utilities.Abstract;
using LibraryDapperExample.Utilities.Concrete;
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
    public class CreateBookCommandHandler : ICommandRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public CreateBookCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var categoryTable = new DataTable();
                categoryTable.Columns.Add("Item", typeof(Guid));
                request.CategoryIds.ForEach(x => categoryTable.Rows.Add(x));
                var libraryTable = new DataTable();
                libraryTable.Columns.Add("Item", typeof(Guid));
                request.LibraryIds.ForEach(t => libraryTable.Rows.Add(t));

                await connection.ExecuteAsync("CreateBooks", new[] {

                    new{ Name = request.Name, WriterId = request.WriterId, CategoryIds = categoryTable , LibraryIds = libraryTable }

                    }, commandType: CommandType.StoredProcedure);

                connection.Close();
                return new CreateBookCommandResponse() { Success = true };
            }
        }
    }
}
