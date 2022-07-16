using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string OwnerId { get; set; }
        public int CategoryId { get; set; }
        public string CoverImage { get; set; }
        [NotMapped]
        public IFormFile ImageFile3 { get; set; }
        public string StoreStatement { get; set; }
    }
}
