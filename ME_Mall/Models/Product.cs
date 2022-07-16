using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductImage { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [ForeignKey("FK_Unit")]
        public int UnitId { get; set; }
    }
}
