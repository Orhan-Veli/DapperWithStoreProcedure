using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class Country
    {
        public Country()
        {
            States = new List<State>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<State> States { get; set; }
    }
}
