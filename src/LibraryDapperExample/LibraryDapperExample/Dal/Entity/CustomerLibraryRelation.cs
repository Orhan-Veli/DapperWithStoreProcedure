using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class CustomerLibraryRelation
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid LibraryId { get; set; }
    }
}
