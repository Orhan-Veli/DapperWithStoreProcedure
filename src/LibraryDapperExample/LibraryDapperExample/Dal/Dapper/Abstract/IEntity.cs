using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Dapper.Abstract
{
    public interface IEntity<T> where T: class,new()
    {
        Task Create(T model);

        Task<T> Get(Guid? Id);

        Task<T> Update(T model);

        Task Delete(Guid id);

        
    }
}
