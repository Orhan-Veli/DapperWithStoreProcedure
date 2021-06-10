using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class District
    {
        public District()
        {
            Libraries = new List<Library>();
            Customers = new List<Customer>();
            Managers = new List<Manager>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CountyId { get; set; }

        public List<Library> Libraries { get; set; }

        public List<Customer> Customers { get; set; }

        public List<Manager> Managers { get; set; }
    }
}
