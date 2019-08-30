using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace course_app.Models
{
    public class login
    {
       
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}