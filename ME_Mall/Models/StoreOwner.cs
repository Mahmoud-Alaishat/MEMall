using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class StoreOwner
    {
        public Store Store { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
