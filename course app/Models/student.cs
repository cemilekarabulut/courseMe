using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace course_app.Models
{
    public class student
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
      
        public byte[] image{ get; set; }
        [Required]
        public int age { get; set; }
        public int section_id { get; set; }

    }
}