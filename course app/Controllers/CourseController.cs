using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using course_app.Models;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using course_app.Helpers;
namespace course_app.Controllers
{
    public class CourseController : Controller
    {
        MySqlConnection conn = new MySqlConnection("database= course; datasource = localhost; port = 3306; username = root; password =0000;");
        // GET: Course
        [HttpPost]
        public ActionResult Index(string button)
        {
            return View("Login");

        }
        public ActionResult Index()
        {
            Session.Remove("ActiveUser");
            Session.Clear();
            return View();


        }

        [HttpPost]
        public ActionResult Login(login a)
        {
            List<string> user = new List<string>();
            string str = "";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"select email,title from login where email='{a.email}' and password='{a.password}';", conn);

            MySqlDataReader MyReader;
            MyReader = cmd.ExecuteReader();
            while (MyReader.Read())
            {
                Console.WriteLine(MyReader["title"].ToString());
                str = MyReader["title"].ToString();
            }

            conn.Close();
            if (String.IsNullOrEmpty(str))
                return View("error");
            else if (str == "student")
            {
                Session.Add("ActiveUser", str);
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand($"select * from student where email='{a.email}' and password='{a.password}';", conn);

                MyReader = cmd2.ExecuteReader();
                while (MyReader.Read())
                {
                    //Console.WriteLine(MyReader["title"].ToString());
                    user.Add(MyReader["id"].ToString());
                    user.Add(MyReader["name"].ToString());
                    user.Add(MyReader["surname"].ToString());
                    user.Add(MyReader["gender"].ToString());
                    user.Add(MyReader["age"].ToString());
                    user.Add(MyReader["email"].ToString());
                    user.Add(MyReader["password"].ToString());
                }

                conn.Close();
                var _courseHelper = new CourseHelper();
                var student = _courseHelper.student(Convert.ToInt32(user[0]));
                student.name = user[1];
                student.surname = user[2];
                student.gender = user[3];
                student.age = Convert.ToInt32(user[4]);
                student.email = user[5];
                student.password = user[6];
                return RedirectToAction("student", student);
                //  return View(student);

            }
            else if (str == "instructor")
            {
                Session.Add("ActiveUser", str);
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand($"select * from instructor where email='{a.email}' and password='{a.password}';", conn);

                MyReader = cmd2.ExecuteReader();
                while (MyReader.Read())
                {
                    //Console.WriteLine(MyReader["title"].ToString());
                    user.Add(MyReader["id"].ToString());
                    user.Add(MyReader["name"].ToString());
                    user.Add(MyReader["surname"].ToString());
                    user.Add(MyReader["gender"].ToString());
                    user.Add(MyReader["age"].ToString());
                    user.Add(MyReader["email"].ToString());
                    user.Add(MyReader["password"].ToString());
                    user.Add(MyReader["field"].ToString());
                }

                conn.Close();
                instructor instructor = new instructor();
                instructor.id = Convert.ToInt32(user[0]);
                instructor.name = user[1];
                instructor.surname = user[2];
                instructor.gender = user[3];
                instructor.age = Convert.ToInt32(user[4]);
                instructor.email = user[5];
                instructor.password = user[6];
                instructor.field = user[7];
                return RedirectToAction("instructor", instructor);
            }
            else if (str == "registrar")
                return View("registrar");

            else
            {
                Session.Add("ActiveUser", str);
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand($"select * from parent where email='{a.email}' and password='{a.password}';", conn);

                MyReader = cmd2.ExecuteReader();
                while (MyReader.Read())
                {
                    //Console.WriteLine(MyReader["title"].ToString());
                    user.Add(MyReader["id"].ToString());
                    user.Add(MyReader["name"].ToString());
                    user.Add(MyReader["surname"].ToString());
                    user.Add(MyReader["gender"].ToString());
                    user.Add(MyReader["age"].ToString());
                    user.Add(MyReader["email"].ToString());
                    user.Add(MyReader["password"].ToString());
                }

                conn.Close();

                parent parent = new parent();
                parent.id = Convert.ToInt32(user[0]);
                parent.name = user[1];
                parent.surname = user[2];
                parent.gender = user[3];
                parent.age = Convert.ToInt32(user[4]);
                parent.email = user[5];
                parent.password = user[6];
                return RedirectToAction("parent", parent);
                
            }
        }


        public ActionResult error()
        {
            return View();
        }
        [HttpPost]

        public ActionResult error(string str)
        {
            return View("Index");
        }


        public ActionResult student(student student)
        {
           
            List<student_main_page> p = new List<student_main_page>();
            //SELECT s.date,c.name,i.name FROM course_records cr left outer join section s on cr.sectionId = s.id left outer join course c on s.courseId=c.id left outer join instructor i on i.id=s.instructorId group BY cr.id ORDER BY cr.id;
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"SELECT s.date,c.name,i.name as names,i.surname,s.id FROM (select * from course_records cr1 where cr1.studentId={student.id}) cr left outer join section s on cr.sectionId = s.id left outer join course c on s.courseId=c.id left outer join instructor i on i.id=s.instructorId group BY cr.id ORDER BY cr.id;", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                p.Add(new student_main_page() { section_date = MyReader["date"].ToString(), course_name = MyReader["name"].ToString(), instructor_name = MyReader["names"].ToString() + " " + MyReader["surname"].ToString(), section_id = Convert.ToInt32(MyReader["id"])});
            }

            conn.Close();

            Ornek a = new Ornek();
            a.student = student;
            a.student_Main_Pages = p;
            return View(a);
        }
        //[HttpPost]
        //public ActionResult student(string str)
        //{
        //    return View();
        //}
        
        [AcceptVerbs(HttpVerbs.Get)]

        public ActionResult Signup()
        {

            return View();

        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Signup(student user)
        {


            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"insert into student(name,surname,email,password,age,gender) values('{user.name}', '{user.surname}', '{user.email}', '{user.password}', '{user.age}', '{user.gender}');", conn);
            MySqlCommand cmd2 = new MySqlCommand($"insert into login(email,password,title) values( '{user.email}', '{user.password}', 'student');", conn);
            MySqlDataReader MyReader;
            MyReader = cmd.ExecuteReader();
            conn.Close();
            conn.Open();
            MyReader = cmd2.ExecuteReader();
            conn.Close();



            return View("Index");

        }


        public ActionResult addCourse(student x)
        {
            List<int> p = new List<int>();
            Ornek ornek = new Ornek();
            List<student_main_page> page = new List<student_main_page>();
            //select cr.sectionId from course_records cr where cr.studentId = {x.id}
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"select cr.sectionId from course_records cr where cr.studentId = {x.id}", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                p.Add(Convert.ToInt32(MyReader["sectionId"]));
            }

            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"select s.id,c.name,i.name as names,s.date from section s left outer join course c on c.id=s.courseId left outer join instructor i on i.id= s.instructorId", conn);

            MyReader = cmd.ExecuteReader();
            while (MyReader.Read())
            {
                if (!p.Contains(Convert.ToInt32(MyReader["id"])))
                {
                    page.Add(new student_main_page { section_id = Convert.ToInt32(MyReader["id"]), course_name = MyReader["name"].ToString(), instructor_name = MyReader["names"].ToString(), section_date = MyReader["date"].ToString() });
                }
            }


            conn.Close();

            ornek.student = x;
            ornek.student_Main_Pages = page;
            return View(ornek);
        }
        public ActionResult grades(student student)
        {
            List<student_main_page> p = new List<student_main_page>();
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"SELECT cr.grade,c.name,s.id FROM (select * from course_records cr1 where cr1.studentId={student.id}) cr left outer join section s on cr.sectionId = s.id left outer join course c on s.courseId=c.id left outer join instructor i on i.id=s.instructorId group BY cr.id ORDER BY cr.id;", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                if (MyReader["grade"] == DBNull.Value)
                    p.Add(new student_main_page() { course_name = MyReader["name"].ToString(), grade = 0 });
                //Console.WriteLine(MyReader["title"].ToString());
                else
                    p.Add(new student_main_page() {  course_name = MyReader["name"].ToString(),grade=Convert.ToInt32(MyReader["grade"]) });
            }

            conn.Close();
            Ornek ornek = new Ornek();
            ornek.student_Main_Pages = p;
            ornek.student = student;
            return View(ornek);
        }
        
        public ActionResult delete_button_student(student stu)
        {

            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"delete from course_records where studentId={stu.id} and sectionId={stu.section_id}", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            conn.Close();
            return RedirectToAction("student", stu);
        }
        public ActionResult add_button_student(student student)
        {
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"insert into course_records (studentId,sectionId) values({student.id},{student.section_id});", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            conn.Close();
            return RedirectToAction("student", student);
        }
        public ActionResult instructor(instructor instructor)
        {
            //SELECT s.date,c.name,i.name as names,i.surname,s.id FROM (select * from section  where instructorId={instructor.id}) s left outer join course c on s.courseId=c.id left outer join instructor i on i.id=s.instructorId group BY s.id ORDER BY s.id;
            List<student_main_page> p = new List<student_main_page>();
              conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"SELECT s.date,c.name,i.name as names,i.surname,s.id FROM (select * from section  where instructorId={instructor.id}) s left outer join course c on s.courseId=c.id left outer join instructor i on i.id=s.instructorId group BY s.id ORDER BY s.id;",conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                p.Add(new student_main_page() { section_date = MyReader["date"].ToString(), course_name = MyReader["name"].ToString(),  section_id = Convert.ToInt32(MyReader["id"]) });
            }
            conn.Close();
            Ornek ornek = new Ornek();
            ornek.instructor = instructor;
            ornek.student_Main_Pages = p;
            return View(ornek);
        }
        //[HttpPost]
        //public ActionResult instructor(string str)
        //{
        //    return View();
        //}
        public ActionResult registrar()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult registrar(string str)
        {
            return View();
        }
        public ActionResult parent(parent parent)
        {
            List<student_list> kids = new List<student_list>();
            List<student_main_page> a = new List<student_main_page>();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"select cr.grade,st.name,st.surname,s.id,c.name as names,st.id as ids,s.date from (select * from children where parentId={parent.id}) ch left outer join student st on st.id=ch.studentId left outer join course_records cr on cr.studentId=ch.studentId left outer join section s on s.id=cr.sectionId left outer join course c on c.id=s.courseId order by st.id;", conn);
            MySqlDataReader MyReader;
            MyReader = cmd.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                kids.Add(new student_list() { course_name = MyReader["names"].ToString(), section_id = Convert.ToInt32(MyReader["id"]), student_name = MyReader["name"].ToString(), student_surname = MyReader["surname"].ToString(),grade = Convert.ToInt32(MyReader["grade"]) ,student_id= Convert.ToInt32(MyReader["ids"]),section_date= MyReader["date"].ToString() });
            }
            for (int i = 0; i < kids.Count; i++)
            {
                a.Add(new student_main_page() { course_name=kids[i].course_name,section_id=kids[i].section_id,grade=kids[i].grade, section_date = kids[i].section_date });
                for (int j = i+1; j < kids.Count;)
                {
                    
                    if (kids[i].student_id == kids[j].student_id)
                    {
                        a.Add(new student_main_page() { course_name = kids[j].course_name, section_id = kids[j].section_id, grade = kids[j].grade ,section_date=kids[j].section_date});
                        kids.RemoveAt(j);
                    }
                    else
                        break;
                }
                kids[i].student_s = new List<student_main_page>(a) ;
                a.RemoveRange(0, a.Count);
            }
         
            conn.Close();
            Ornek ornek = new Ornek();
            ornek.parent=parent;
            ornek.students = kids;
            return PartialView(ornek);
        }
        //[HttpPost]
        //public ActionResult parent(string str)
        //{
        //    return View();
        //}
        public ActionResult showStudent(instructor instructor)
        {
            //select st.name,cr.grade from (select * from course_records where sectionId=1) cr left outer join student st on st.id=cr.studentId;
            int section_id = 0;
            string course_name = "";
            List<student_list> p = new List<student_list>();
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"select st.id,st.name,st.surname,cr.grade,s.id as sectionid,c.name as coursename from (select * from course_records where sectionId={instructor.section_id}) cr left outer join student st on st.id=cr.studentId left outer join section s on s.id=cr.sectionId left outer join course c on c.id=s.courseId; ", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                if (MyReader["grade"] == DBNull.Value)
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), grade = 0 });
                else
                    p.Add(new student_list() {  student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]) , student_surname = MyReader["surname"].ToString() , grade =Convert.ToDouble( MyReader["grade"] )});
                section_id = Convert.ToInt32(MyReader["sectionid"]);
                course_name = MyReader["coursename"].ToString();
            }
            conn.Close();
            Ornek ornek = new Ornek();
            ornek.instructor = instructor;
            ornek.students = p;
            ornek.section_id = section_id;
            ornek.course_name = course_name;
            return View(ornek);
        }
        public ActionResult delete_course_instructor(instructor instructor)
        {
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"delete from section where instructorId={instructor.id} and id={instructor.section_id}", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            conn.Close();

            return RedirectToAction("instructor", instructor);
        }

        public ActionResult update_grade(instructor instructor, instructor instructor2)
        {
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"update course_records set grade={instructor.grade} where sectionId={instructor2.section_id} and studentId={instructor2.student_id}", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            conn.Close();
            return RedirectToAction("showStudent",instructor2);
        }


        public ActionResult addImage()
        {

            return View();
        }
        [HttpPost]

        public ActionResult addImage(student a, HttpPostedFileBase image1)
        {
            if (image1 != null)
            {
                a.image = new byte[image1.ContentLength];
                image1.InputStream.Read(a.image, 0, image1.ContentLength);
            }
            conn.Open();
            MySqlCommand addPhoto = new MySqlCommand($"insert into student(image) values(@img);", conn);
            addPhoto.Prepare();

            addPhoto.Parameters.Add("@img", MySqlDbType.Binary, a.image.Length);
            addPhoto.Parameters["@img"].Value = a.image;
            addPhoto.ExecuteNonQuery();
            conn.Close();
            return View(a);
        }
        public List<student> item = new List<student>();

        public ActionResult retrieveImage()
        {
            byte[] data = null;

            student a = new student();
            conn.Open();
            MySqlCommand show = new MySqlCommand();
            show.Connection = conn;
            show.CommandText = $"SELECT image FROM student WHERE id=8";
            MySqlDataReader MyReader;
            MyReader = show.ExecuteReader();
            while (MyReader.Read())
            {
                data = (byte[])MyReader["image"];
            }

            conn.Close();
            a.image = data;
            item.Add(a);
            return View(item);
        }
       
    }


}