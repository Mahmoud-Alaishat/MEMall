using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class NewsAndArticles
    {
        public int Id { get; set; }
        public string Title { get; set;}
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public string WriterId { get; set; }
        public string PostImg { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
