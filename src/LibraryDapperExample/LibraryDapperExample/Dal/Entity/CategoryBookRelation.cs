using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class CategoryBookRelation
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public Guid CategoryId { get; set; }
    }
}
