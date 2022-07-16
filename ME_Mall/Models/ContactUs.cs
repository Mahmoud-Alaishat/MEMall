using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int ShowHide { get; set; }
    }
}
