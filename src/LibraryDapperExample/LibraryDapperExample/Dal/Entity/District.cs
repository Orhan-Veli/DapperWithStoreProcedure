using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class District
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CountyId { get; set; }
    }
}
