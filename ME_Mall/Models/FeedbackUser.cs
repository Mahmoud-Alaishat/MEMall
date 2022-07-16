using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME_Mall.Models
{
    public class FeedbackUser
    {
        public Feedback Feedback { get; set; }
        public User User { get; set; }
        public Status Status { get; set; }
    }
}
