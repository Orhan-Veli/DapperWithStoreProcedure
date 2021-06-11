using LibraryDapperExample.Dal.Dapper.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LibraryDapperExample.Utilities.Abstract;
using LibraryDapperExample.Utilities.Concrete;

namespace LibraryDapperExample.Dal.Dapper.Concrete
{
    public class Entity<T> : IEntity<T> where T : class,new()
    {
        private readonly IConfiguration _configuration;
        public Entity(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task Create(T model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<T>> Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<List<T>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
