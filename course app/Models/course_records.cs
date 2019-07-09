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
}