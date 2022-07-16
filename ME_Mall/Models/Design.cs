using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class Design
    {
        public string Id { get; set; }
        public string SlideImage1 { get; set; }
        [NotMapped]
        public IFormFile ImageFile1 { get; set; }
        public string SlideImage2 { get; set; }
        [NotMapped]
        public IFormFile ImageFile2 { get; set; }
        public string SlideImage3 { get; set; }
        [NotMapped]
        public IFormFile ImageFile3 { get; set; }
        public string SubText1 { get; set; }
        public string SubText2 { get; set; }
        public string SubText3 { get; set; }
        public string MainText1 { get; set; }
        public string MainText2 { get; set; }
        public string MainText3 { get; set; }
        public string UserId { get; set; }
    }
}
