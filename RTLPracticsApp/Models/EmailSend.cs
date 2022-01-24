using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTLPracticsApp.Models
{
    public class EmailSend
    {
        public string[] To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Password { get; set; }
        public string FormEmail { get; set; }
        public string[] ToCCEmail { get; set; }
        public string[] ToBCCEmail { get; set; }
    }
}