﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Dal.Entity
{
    public class Library
    {
        public Library()
        {
            CustomerLibraryRelations = new List<CustomerLibraryRelation>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid AddressId { get; set; }

        public List<CustomerLibraryRelation> CustomerLibraryRelations { get; set; }
    }
}
