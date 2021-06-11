using LibraryDapperExample.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Utilities.Concrete
{
    public class Result<T> : IResult<T>
    {
        public Result(string message,bool success, T data ) 
        {
            Message = message;
            success = Success;
            Data = data;
        }

        public Result(string message,bool success)
        {
            Message = message;
            Success = success;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success,T data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; }
        public string Message { get;  }
        public T Data { get; }
    }
}
