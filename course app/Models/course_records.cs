using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace course_app.Models
{
    public class course_records
    {
        public int id { get; set; }
        public int sectionId { get; set; }
        public int studentId { get; set; }
        public float grade { get; set; }
    }
    public class Ornek
    {
        public student student { get; set; }
        public course_records course_records { get; set; }
        public course course { get; set; }
        public instructor instructor { get; set; }
        public login login { get; set; }
        public parent parent { get; set; }
        public registrar registrar { get; set; }
        public section section { get; set; }
        public List<student_main_page> student_Main_Pages { get; set; }
        public List<student_list> students { get; set; }
        public int section_id { get; set; }
        public string course_name { get; set; }
        
    }
}