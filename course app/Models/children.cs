using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace course_app.Models
{
    public class children
    {
        public int parent_id { get; set; }
        [Required]
        public int student_id { get; set; }
    }
}