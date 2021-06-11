using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class Book
    {
        public Book()
        {
            CategoryBookRelations = new List<CategoryBookRelation>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid WriterId { get; set; }

        public List<Category> CategoryIds { get; set; }
        public List<Library> LibraryIds { get; set; }
        public List<CategoryBookRelation> CategoryBookRelations { get; set; }
    }
}
