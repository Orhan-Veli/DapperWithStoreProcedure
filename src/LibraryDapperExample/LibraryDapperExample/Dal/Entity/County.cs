using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class County
    {
        public County()
        {
            Districts = new List<District>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid StateId { get; set; }

        public List<District> Districts { get; set; }
    }
}
