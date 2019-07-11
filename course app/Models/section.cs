using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace course_app.Models
{
    public class section
    {
        public int id { get; set; }
        public int courseId { get; set; }
        public int instructorId { get; set; }
        public int date { get; set; }
    }

  
}