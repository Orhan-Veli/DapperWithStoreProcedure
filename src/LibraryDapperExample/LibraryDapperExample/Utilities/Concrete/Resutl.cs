using LibraryDapperExample.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Utilities.Concrete
{
    public class Resutl<T> : IResult<T>
    {
        public Resutl(string message,bool success, T data ) 
        {
            Message = message;
            success = Success;
            Data = data;
        }

        public Resutl(string message,bool success)
        {
            Message = message;
            Success = success;
        }

        public Resutl(bool success)
        {
            Success = success;
        }

        public Resutl(bool success,T data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; }
        public string Message { get;  }
        public T Data { get; }
    }
}
