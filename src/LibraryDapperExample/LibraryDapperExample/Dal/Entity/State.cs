using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class State
    {
        public State()
        {
            Counties = new List<County>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public List<County> Counties { get; set; }
    }
}
