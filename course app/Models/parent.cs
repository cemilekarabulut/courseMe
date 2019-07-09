using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace course_app.Models
{
    public class parent
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public byte[] image { get; set; }
        public int studentId { get; set; }
    }
}