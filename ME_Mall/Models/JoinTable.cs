using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class JoinTable
    {
        public Product product { get; set; }
        public ProductStore productStore { get; set; }
        public Order order { get; set; }
        public OrderProduct orderProduct { get; set; }
        public Store store { get;set; }
        public Unit Unit { get; set; }
         

    }
}
