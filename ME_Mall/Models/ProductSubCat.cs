using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class ProductSubCat
    {
        public Product Product { get; set; }
        public ProductStore ProductStore { get; set; }
        public Store Store { get; set; }
        public SubCategory SubCategory { get; set; }
        public Unit Unit { get; set; }

    }
}
