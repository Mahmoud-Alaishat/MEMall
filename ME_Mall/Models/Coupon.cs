using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Byte IsActive { get; set; }
        public int DiscountValue { get; set; }
    }
}
