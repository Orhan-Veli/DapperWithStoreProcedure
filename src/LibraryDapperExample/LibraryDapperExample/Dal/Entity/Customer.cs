using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class Customer
    {
        public Customer()
        {
            CustomerLibraryRelations = new List<CustomerLibraryRelation>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Guid AddressId { get; set; }

        public List<CustomerLibraryRelation> CustomerLibraryRelations { get; set; } 
    }
}
