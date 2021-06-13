using LibraryDapperExample.Dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Model
{
    public class BookModel
    {
        public string Name { get; set; }

        public Guid WriterId { get; set; }

        public List<Category> Categories { get; set; }

        public List<Library> Libraries { get; set; }
    }
}
