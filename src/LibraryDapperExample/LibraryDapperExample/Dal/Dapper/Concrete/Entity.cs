using LibraryDapperExample.Dal.Dapper.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryDapperExample.Dal.Dapper.Concrete
{
    public class Entity<T> : IEntity<T> where T : class,new()
    {
        private readonly IConfiguration _configuration;
        public Entity(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Create(T model)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
            }
        }

        public async Task Delete(Guid id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
            }
        }

        public async Task<T> Get(Guid? Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
            }
        }

        public async Task<T> Update(T model)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
            }
        }
    }
}
