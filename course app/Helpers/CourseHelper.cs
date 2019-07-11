using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace course_app.Helpers
{
    public class CourseHelper
    {
        public course_app.Models.student student(int student_id)
        {
            var student = new course_app.Models.student();
            student.id = student_id;
            return student;
        }
    }
}