using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace course_app.Models
{
    public class section
    { 
        public List<string> course_names { get; set; }
        public List<string> instructor_names { get; set; }
        public int id { get; set; }
        public string course_name { get; set; }
        public int instructor_id { get; set; }
        public string day { get; set; }
        public string hour { get; set; }
    }

  
}