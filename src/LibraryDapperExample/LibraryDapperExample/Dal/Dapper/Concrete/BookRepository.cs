using Dapper;
using LibraryDapperExample.Dal.Dapper.Abstract;
using LibraryDapperExample.Utilities.Abstract;
using LibraryDapperExample.Dal.Entity;
using LibraryDapperExample.Utilities.Concrete;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LibraryDapperExample.Model;

namespace LibraryDapperExample.Dal.Dapper.Concrete
{
    public class BookRepository : IEntity<BookViewModel>, IBook
    {
        private static IConfiguration _configuration;
        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Create(BookViewModel model)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@Name",model.Name);
                //parameters.Add("@WriterId", model.WriterId);
                //parameters.Add("@CategoryIds", model.CategoryIds);
                //parameters.Add("@LibraryIds", model.LibraryIds);
                await connection.ExecuteAsync("CreateBooks",parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
            }
        }

        public async Task Delete(Guid id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                await connection.ExecuteAsync("DeleteBooks",parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
            }
        }

        public async Task<IResult<BookViewModel>> Get(Guid Id)
        {
            var book = new BookViewModel();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                book = connection.QueryAsync<BookViewModel>("GetBook", parameters,commandType:CommandType.StoredProcedure).Result.FirstOrDefault();
                if(book==null) return new Result<BookViewModel>(false);
                connection.Close();
            }
            return new Result<BookViewModel>(true,book);
        }

        public async Task<IResult<List<BookViewModel>>> GetAll()
        {
            //var book = new List<Book>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", null);
                var book = connection.Query<BookViewModel>("GetBook", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                connection.Close();
                return new Result<List<BookViewModel>>(false,book);
            }
            return new Result<List<BookViewModel>>(false);
        }

        public async Task Update(BookViewModel model)
        {
            var book = new BookViewModel();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@BookId",model.Id);
                //parameters.Add("@BookName",model.Name);
                //parameters.Add("@WriterId", model.WriterId);
                await connection.QueryAsync<BookViewModel>("UpdateBook",parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
            }
        }
    }
}
