using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public List<Product> Products { get; set; }

    }
}
