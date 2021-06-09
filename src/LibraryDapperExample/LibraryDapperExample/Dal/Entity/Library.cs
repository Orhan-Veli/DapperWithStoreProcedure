using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class Library
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public District AddressId { get; set; }
    }
}
