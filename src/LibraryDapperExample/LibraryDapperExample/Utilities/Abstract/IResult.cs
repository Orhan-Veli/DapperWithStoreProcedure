using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Utilities.Abstract
{
    public interface IResult<T>
    {
        public bool Success { get; }

        public string Message { get; }

        public T Data { get;}

    }
}
