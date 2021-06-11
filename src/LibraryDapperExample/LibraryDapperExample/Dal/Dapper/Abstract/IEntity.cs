using LibraryDapperExample.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.Abstract
{
    public interface IEntity<T> where T: class,new()
    {
        Task Create(T model);

        Task<IResult<T>> Get(Guid Id);

        Task Update(T model);

        Task Delete(Guid id);

        Task<IResult<List<T>>> GetAll();
        
    }
}
