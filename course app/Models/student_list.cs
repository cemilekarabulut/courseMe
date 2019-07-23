using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace course_app.Models
{
    public class student_list
    {
        public int student_id { get; set; }
        public string student_name { get; set; }
        public string student_surname { get; set; }
        public List<student_main_page> student_s { get; set; }
        public double midterm { get; set; }
        public double final { get; set; }
        public string course_name { get; set; }
        public int section_id { get; set; }
        public string section_date { get; set; }
    }
}