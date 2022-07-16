using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class JoinTable2
    {
        public Order order { get; set; }
        public OrderProduct orderProduct { get; set; }
        public Product product { get; set; }
        public Unit Unit { get; set; }
        public Status Status { get; set; }
    }
}
