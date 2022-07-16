using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string FeedbackText { get; set; }
        public int FeedbackStatus { get; set; }
        public string UserId { get; set; }
    }
}
