using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal Total { get; set; }
    }
}
