using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public string UserId { get; set; }
        public string Notes { get; set; }
        public string DeliveryId { get; set; }
    }
}
