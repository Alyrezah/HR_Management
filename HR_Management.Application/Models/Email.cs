using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Models
{
    public class Email
    {
        public string DestinationEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
