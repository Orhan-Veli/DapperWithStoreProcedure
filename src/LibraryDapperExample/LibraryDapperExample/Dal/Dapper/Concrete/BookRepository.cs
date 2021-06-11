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

namespace LibraryDapperExample.Dal.Dapper.Concrete
{
    public class BookRepository : IEntity<Book>, IBook
    {
        private static IConfiguration _configuration;
        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Create(Book model)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name",model.Name);
                parameters.Add("@WriterId", model.WriterId);
                parameters.Add("@CategoryIds", model.CategoryIds);
                parameters.Add("@LibraryIds", model.LibraryIds);
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

        public async Task<IResult<Book>> Get(Guid Id)
        {
            var book = new Book();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                book = connection.QueryAsync<Book>("GetBook", parameters,commandType:CommandType.StoredProcedure).Result.FirstOrDefault();
                connection.Close();
            }
            return new Result<Book>(true,book);
        }

        public async Task<IResult<List<Book>>> GetAll()
        {
            var book = new List<Book>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();                
                book = connection.QueryAsync<Book>("GetBook").Result.ToList();
                connection.Close();
            }
            return new Result<List<Book>>(true,book);
        }

        public async Task Update(Book model)
        {
            var book = new Book();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BookId",model.Id);
                parameters.Add("@BookName",model.Name);
                parameters.Add("@WriterId", model.WriterId);
                await connection.QueryAsync<Book>("UpdateBook",parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
            }
        }
    }
}
