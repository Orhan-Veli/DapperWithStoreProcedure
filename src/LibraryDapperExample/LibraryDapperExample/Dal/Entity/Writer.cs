using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class Writer
    {
        public Writer()
        {
            Books = new List<Book>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Guid AddressId { get; set; }

        public List<Book> Books { get; set; }
    }
}
