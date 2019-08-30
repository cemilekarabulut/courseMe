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
            temp = null;
            temp1=null;
            temporary = null;
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
            {
                Session.Add("ActiveUser", str);
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand($"select * from registrar where email='{a.email}' and password='{a.password}';", conn);

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
                registrar registrar = new registrar();
                registrar.id = Convert.ToInt32(user[0]);
                registrar.name = user[1];
                registrar.surname = user[2];
                registrar.gender = user[3];
                registrar.age = Convert.ToInt32(user[4]);
                registrar.email = user[5];
                registrar.password = user[6];

                return RedirectToAction("registrar", registrar);
            }


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
                p.Add(new student_main_page() { section_date = MyReader["date"].ToString(), course_name = MyReader["name"].ToString(), instructor_name = MyReader["names"].ToString() + " " + MyReader["surname"].ToString(), section_id = Convert.ToInt32(MyReader["id"]) });
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
        public ActionResult Signup(student user,HttpPostedFileBase image1)
        {
            //if (user.name == null || user.surname == null || user.email == null || user.password == null || user.gender == null || user.age==0) {
            //    return View("error");
            //}

            user.image = new byte[1]; 
            user.image[0] = 0x20;

            if (ModelState.IsValid == true)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"insert into student (name,surname,email,password,age,gender) values('{user.name}', '{user.surname}', '{user.email}', '{user.password}', '{user.age}', '{user.gender}');", conn);
                MySqlCommand cmd2 = new MySqlCommand($"insert into login(email,password,title) values( '{user.email}', '{user.password}', 'student');", conn);
                MySqlCommand cmd3 = new MySqlCommand("SELECT id FROM student ORDER BY id DESC LIMIT 0, 1", conn);
                MySqlDataReader MyReader;
                MyReader = cmd.ExecuteReader();
                conn.Close();
                conn.Open();
                MyReader = cmd2.ExecuteReader();
                conn.Close();
                conn.Open();
                MyReader = cmd3.ExecuteReader();
                while (MyReader.Read())
                {
                    user.id = Convert.ToInt32(MyReader["id"]);
                }
                conn.Close();
                if (image1 != null)
                {
                    user.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(user.image, 0, image1.ContentLength);
                }
                conn.Open();
                MySqlCommand addPhoto = new MySqlCommand($"update student set image=@img where id='{user.id}';", conn);
                addPhoto.Prepare();

                addPhoto.Parameters.Add("@img", MySqlDbType.Binary, user.image.Length);
                addPhoto.Parameters["@img"].Value = user.image;
                addPhoto.ExecuteNonQuery();
                conn.Close();

                return View("Index");
            }
            else
                ModelState.AddModelError("Error", "Lütfen hataları gideriniz.");

            return View(user);

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
            MySqlCommand cmd = new MySqlCommand($"select s.id,c.name,i.name as names,i.surname,s.date from section s left outer join course c on c.id=s.courseId left outer join instructor i on i.id= s.instructorId", conn);

            MyReader = cmd.ExecuteReader();
            while (MyReader.Read())
            {
                if (!p.Contains(Convert.ToInt32(MyReader["id"])))
                {
                    page.Add(new student_main_page { section_id = Convert.ToInt32(MyReader["id"]), course_name = MyReader["name"].ToString(), instructor_name = MyReader["names"].ToString() + " " + MyReader["surname"].ToString(), section_date = MyReader["date"].ToString() });
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
            MySqlCommand cmd2 = new MySqlCommand($"SELECT cr.midterm,c.name,s.id,cr.final FROM (select * from course_records cr1 where cr1.studentId={student.id}) cr left outer join section s on cr.sectionId = s.id left outer join course c on s.courseId=c.id left outer join instructor i on i.id=s.instructorId group BY cr.id ORDER BY cr.id;", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                if (MyReader["midterm"] == DBNull.Value && MyReader["final"] == DBNull.Value)
                    p.Add(new student_main_page() { course_name = MyReader["name"].ToString(), midterm = -2, final = -2 });
                else if (MyReader["midterm"] == DBNull.Value)
                    p.Add(new student_main_page() { course_name = MyReader["name"].ToString(), midterm = -2, final = Convert.ToDouble(MyReader["final"]) });
                //Console.WriteLine(MyReader["title"].ToString());
                else if (MyReader["final"] == DBNull.Value)
                    p.Add(new student_main_page() { course_name = MyReader["name"].ToString(), midterm = Convert.ToDouble(MyReader["midterm"]), final = -2 });
                else
                    p.Add(new student_main_page() { course_name = MyReader["name"].ToString(), midterm = Convert.ToDouble(MyReader["midterm"]), final = Convert.ToDouble(MyReader["final"]) });
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
        public static instructor ins = new instructor();
        public ActionResult instructor(instructor instructor)
        {
            ins = instructor;
            //SELECT s.date,c.name,i.name as names,i.surname,s.id FROM (select * from section  where instructorId={instructor.id}) s left outer join course c on s.courseId=c.id left outer join instructor i on i.id=s.instructorId group BY s.id ORDER BY s.id;
            List<student_main_page> p = new List<student_main_page>();
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"SELECT s.date,c.name,i.name as names,i.surname,s.id FROM (select * from section  where instructorId={instructor.id}) s left outer join course c on s.courseId=c.id left outer join instructor i on i.id=s.instructorId group BY s.id ORDER BY s.id;", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                p.Add(new student_main_page() { section_date = MyReader["date"].ToString(), course_name = MyReader["name"].ToString(), section_id = Convert.ToInt32(MyReader["id"]) });
            }
            conn.Close();
            Ornek ornek = new Ornek();
            ornek.instructor = instructor;
            ornek.student_Main_Pages = p;
            return View(ornek);
        }
        public ActionResult forJava()
        {
         
            return RedirectToAction("instructor", ins);
        }
        //[HttpPost]
        //public ActionResult instructor(string str)
        //{
        //    return View();
        //}
        public ActionResult registrar(registrar registrar)
        {
            List<student_main_page> p = new List<student_main_page>();
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand("select c.name as names,i.name,s.id,i.surname from course c left outer join section s on s.courseId=c.id left outer join instructor i on i.id=s.instructorId order by c.name", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                if (MyReader["id"] == DBNull.Value)
                    p.Add(new student_main_page() { course_name = MyReader["names"].ToString() });
                else
                    p.Add(new student_main_page() { course_name = MyReader["names"].ToString(), instructor_name = MyReader["name"].ToString() + " " + MyReader["surname"].ToString(), section_id = Convert.ToInt32(MyReader["id"]) });
                //Console.WriteLine(MyReader["title"].ToString());

            }
            conn.Close();
            Ornek ornek = new Ornek();
            ornek.student_Main_Pages = p;
            ornek.registrar = registrar;

            return View(ornek);
        }
        //[HttpPost]
        //public ActionResult registrar(string str)
        //{
        //    return View();
        //}
        public ActionResult parent(parent parent)
        {
            List<student_list> kids = new List<student_list>();
            List<student_main_page> a = new List<student_main_page>();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"select cr.midterm,st.name,st.surname,s.id,c.name as names,st.id as ids,s.date,cr.final from (select * from children where parentId={parent.id}) ch left outer join student st on st.id=ch.studentId left outer join course_records cr on cr.studentId=ch.studentId left outer join section s on s.id=cr.sectionId left outer join course c on c.id=s.courseId order by st.id;", conn);
            MySqlDataReader MyReader;
            MyReader = cmd.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                if (string.IsNullOrEmpty(MyReader["names"].ToString()))
                {
                    kids.Add(new student_list() { course_name = "", section_id = 0, student_name = MyReader["name"].ToString(), student_surname = MyReader["surname"].ToString(), midterm = -2, student_id = Convert.ToInt32(MyReader["ids"]), section_date = "", final = -2 });
                }
                else
                {
                    if (MyReader["midterm"] == DBNull.Value && MyReader["final"] == DBNull.Value)
                        kids.Add(new student_list() { course_name = MyReader["names"].ToString(), section_id = Convert.ToInt32(MyReader["id"]), student_name = MyReader["name"].ToString(), student_surname = MyReader["surname"].ToString(), midterm = -2, final = -2, student_id = Convert.ToInt32(MyReader["ids"]), section_date = MyReader["date"].ToString() });
                    else if (MyReader["midterm"] == DBNull.Value)
                        kids.Add(new student_list() { course_name = MyReader["names"].ToString(), section_id = Convert.ToInt32(MyReader["id"]), student_name = MyReader["name"].ToString(), student_surname = MyReader["surname"].ToString(), midterm = -2, final = Convert.ToDouble(MyReader["final"]), student_id = Convert.ToInt32(MyReader["ids"]), section_date = MyReader["date"].ToString() });
                    else if (MyReader["final"] == DBNull.Value)
                        kids.Add(new student_list() { course_name = MyReader["names"].ToString(), section_id = Convert.ToInt32(MyReader["id"]), student_name = MyReader["name"].ToString(), student_surname = MyReader["surname"].ToString(), midterm = Convert.ToDouble(MyReader["midterm"]), final = -2, student_id = Convert.ToInt32(MyReader["ids"]), section_date = MyReader["date"].ToString() });
                    else
                        kids.Add(new student_list() { course_name = MyReader["names"].ToString(), section_id = Convert.ToInt32(MyReader["id"]), student_name = MyReader["name"].ToString(), student_surname = MyReader["surname"].ToString(), midterm = Convert.ToDouble(MyReader["midterm"]), final = Convert.ToDouble(MyReader["final"]), student_id = Convert.ToInt32(MyReader["ids"]), section_date = MyReader["date"].ToString() });
                }
            }
            for (int i = 0; i < kids.Count; i++)
            {
                a.Add(new student_main_page() { course_name = kids[i].course_name, section_id = kids[i].section_id, midterm = kids[i].midterm, section_date = kids[i].section_date, final = kids[i].final });
                for (int j = i + 1; j < kids.Count;)
                {

                    if (kids[i].student_id == kids[j].student_id)
                    {
                        a.Add(new student_main_page() { course_name = kids[j].course_name, section_id = kids[j].section_id, midterm = kids[j].midterm, section_date = kids[j].section_date, final = kids[j].final });
                        kids.RemoveAt(j);
                    }
                    else
                        break;
                }
                kids[i].student_s = new List<student_main_page>(a);
                a.RemoveRange(0, a.Count);
            }

            conn.Close();
            Ornek ornek = new Ornek();
            ornek.parent = parent;
            ornek.students = kids;
            return PartialView(ornek);
        }
        //[HttpPost]
        //public ActionResult parent(string str)
        //{
        //    return View();
        //}
        public static Ornek temporary = new Ornek();

        public ActionResult showStudent(instructor instructor)
        {
            //select st.name,cr.grade from (select * from course_records where sectionId=1) cr left outer join student st on st.id=cr.studentId;
            int section_id = 0;
            string course_name = "";
            List<student_list> p = new List<student_list>();
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"select st.id,st.name,st.surname,cr.midterm,s.id as sectionid,c.name as coursename,cr.final from (select * from course_records where sectionId={instructor.section_id}) cr left outer join student st on st.id=cr.studentId left outer join section s on s.id=cr.sectionId left outer join course c on c.id=s.courseId; ", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                if (MyReader["midterm"] == DBNull.Value && MyReader["final"] == DBNull.Value)
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), midterm = -2, final = -2 });
                else if (MyReader["final"] == DBNull.Value)
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), midterm = Convert.ToDouble(MyReader["midterm"]), final = -2 });
                else if (MyReader["midterm"] == DBNull.Value)
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), final = Convert.ToDouble(MyReader["final"]), midterm = -2 });
                else
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), midterm = Convert.ToDouble(MyReader["midterm"]), final = Convert.ToDouble(MyReader["final"]) });
        
            }
            conn.Close();
            conn.Open();
            MySqlCommand command = new MySqlCommand($"select c.name from (select courseId from section where id={instructor.section_id}) s left outer join course c on c.id=s.courseId;", conn);
            MyReader = command.ExecuteReader();
            while (MyReader.Read())
            {
                
                course_name = MyReader["name"].ToString();
            }
            conn.Close();
            Ornek ornek = new Ornek();
            ornek.instructor = instructor;
            ornek.students = p;
            ornek.section_id = instructor.section_id;
            ornek.course_name = course_name;
            temporary = ornek;
            return View(ornek);
        }

        public ActionResult showstudents()
        {
            List<student_list> list = new List<student_list>();
            list = temporary.students;
            if (list.Count==0)
            {
                list.Add(new student_list() { section_id = temporary.section_id , course_name = temporary.course_name , section_date = temporary.instructor.name + " " + temporary.instructor.surname });
            }
            else { 
            list[0].section_id = temporary.section_id;
            list[0].course_name = temporary.course_name;
            list[0].section_date = temporary.instructor.name + " " + temporary.instructor.surname;}
            return Json(list, JsonRequestBehavior.AllowGet);
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

        public ActionResult update_midterm(instructor instructor, instructor instructor2)
        {
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"update course_records set midterm={instructor.midterm} where sectionId={instructor2.section_id} and studentId={instructor2.student_id}", conn);

            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            conn.Close();
            return RedirectToAction("showStudent", instructor2);
        }
        public ActionResult update_final(instructor instructor, instructor instructor2)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"update course_records set final={instructor.final} where sectionId={instructor2.section_id} and studentId={instructor2.student_id}", conn);

            MySqlDataReader MyReader;
            MyReader = cmd.ExecuteReader();
            conn.Close();
            return RedirectToAction("showStudent", instructor2);
        }

        public ActionResult ViewSection(registrar registrar)
        {

            List<student_list> p = new List<student_list>();
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"select st.id,st.name,st.surname,cr.midterm,s.id as sectionid,c.name as coursename,cr.final from (select * from course_records where sectionId={registrar.section_id}) cr left outer join student st on st.id=cr.studentId left outer join section s on s.id=cr.sectionId left outer join course c on c.id=s.courseId; ", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());
                if (MyReader["midterm"] == DBNull.Value && MyReader["final"] == DBNull.Value)
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), midterm = -2, final = -2 });
                else if (MyReader["final"] == DBNull.Value)
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), midterm = Convert.ToDouble(MyReader["midterm"]), final = -2 });
                else if (MyReader["midterm"] == DBNull.Value)
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), final = Convert.ToDouble(MyReader["final"]), midterm = -2 });
                else
                    p.Add(new student_list() { student_name = MyReader["name"].ToString(), student_id = Convert.ToInt32(MyReader["id"]), student_surname = MyReader["surname"].ToString(), midterm = Convert.ToDouble(MyReader["midterm"]), final = Convert.ToDouble(MyReader["final"]) });


            }
            conn.Close();
            Ornek ornek = new Ornek();
            ornek.registrar = registrar;
            ornek.students = p;
            //ornek.section_id = section_id;
            //ornek.course_name = course_name;
            return View(ornek);

        }
        public ActionResult studentList(registrar registrar)
        {
            List<student> p = new List<student>();
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand($"select st.id,st.name,st.surname,st.age,st.gender,st.email from student st order by st.id", conn);
            MySqlDataReader MyReader;
            MyReader = cmd2.ExecuteReader();
            while (MyReader.Read())
            {
                //Console.WriteLine(MyReader["title"].ToString());

                p.Add(new student() { age = Convert.ToInt32(MyReader["age"]), name = MyReader["name"].ToString(), id = Convert.ToInt32(MyReader["id"]), surname = MyReader["surname"].ToString(), gender = MyReader["gender"].ToString(), email = MyReader["email"].ToString() });



            }
            conn.Close();
            Ornek ornek = new Ornek();
            ornek.registrar = registrar;
            ornek.studentList = p;
            return View(ornek);
        }
        public static registrar temp = new registrar();
        public ActionResult signTeacher(registrar registrar)
        {

            temp = registrar;
            return View();
        }

        [HttpPost]
        public ActionResult signTeacher(instructor instructor, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid == true)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"insert into instructor(name,surname,email,password,age,gender,field) values('{instructor.name}', '{instructor.surname}', '{instructor.email}', '{instructor.password}', '{instructor.age}', '{instructor.gender}','{instructor.field}');", conn);
                MySqlCommand cmd2 = new MySqlCommand($"insert into login(email,password,title) values( '{instructor.email}', '{instructor.password}', 'instructor');", conn);
                MySqlCommand cmd3 = new MySqlCommand("SELECT id FROM instructor ORDER BY id DESC LIMIT 0, 1", conn);
                MySqlDataReader MyReader;
                MyReader = cmd.ExecuteReader();

                conn.Close();
                conn.Open();
                MyReader = cmd2.ExecuteReader();
                conn.Close();
                conn.Open();
                MyReader = cmd3.ExecuteReader();
                while (MyReader.Read())
                {
                    instructor.id = Convert.ToInt32(MyReader["id"]);
                }
                conn.Close();
                registrar registrar = new registrar();
                registrar = temp;
                temp = null;
                if (image1 != null)
                {
                    instructor.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(instructor.image, 0, image1.ContentLength);
                }
                conn.Open();
                MySqlCommand addPhoto = new MySqlCommand($"update instructor set image=@img where id='{instructor.id}';", conn);
                addPhoto.Prepare();

                addPhoto.Parameters.Add("@img", MySqlDbType.Binary, instructor.image.Length);
                addPhoto.Parameters["@img"].Value = instructor.image;
                addPhoto.ExecuteNonQuery();
                conn.Close();
                
                return RedirectToAction("registrar", registrar);


            }
            else
                ModelState.AddModelError("Error", "Lütfen hataları gideriniz.");

            return View(instructor);

        }

        public ActionResult signParent(registrar registrar)
        {
            temp = registrar;
            return View();
        }
        [HttpPost]
        public ActionResult signParent(parent parent, HttpPostedFileBase image1)
        {

            if (ModelState.IsValid == true)

            {
                int temp_id = 0;
                MySqlDataReader MyReader;

                MySqlCommand cmd = new MySqlCommand($"insert into parent(name,surname,email,password,age,gender) values('{parent.name}', '{parent.surname}', '{parent.email}', '{parent.password}', '{parent.age}', '{parent.gender}');", conn);
                MySqlCommand cmd2 = new MySqlCommand($"insert into login(email,password,title) values( '{parent.email}', '{parent.password}', 'parent');", conn);
                MySqlCommand command = new MySqlCommand($"select parent.id from parent where email='{parent.email}' and password= '{parent.password}';", conn);
                MySqlCommand cmd4 = new MySqlCommand("SELECT id FROM parent ORDER BY id DESC LIMIT 0, 1", conn);
                conn.Open();
                MyReader = cmd.ExecuteReader();
                conn.Close();
                conn.Open();
                MyReader = cmd2.ExecuteReader();
                conn.Close();
                conn.Open();
                MyReader = command.ExecuteReader();
                while (MyReader.Read())
                {
                    temp_id = Convert.ToInt32(MyReader["id"]);
                }
                conn.Close();
                if (parent.student_id != 0)
                {
                    MySqlCommand cmd3 = new MySqlCommand($"insert into children(studentId,parentId) values('{parent.student_id}', '{temp_id}');", conn);



                    conn.Open();
                    MyReader = cmd3.ExecuteReader();
                    conn.Close();
                }
                conn.Open();
                MyReader = cmd4.ExecuteReader();
                while (MyReader.Read())
                {
                    parent.id = Convert.ToInt32(MyReader["id"]);
                }
                conn.Close();
                registrar registrar = new registrar();
                registrar = temp;
                temp = null;
                if (image1 != null)
                {
                    parent.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(parent.image, 0, image1.ContentLength);
                }
                conn.Open();
                MySqlCommand addPhoto = new MySqlCommand($"update parent set image=@img where id='{parent.id}';", conn);
                addPhoto.Prepare();

                addPhoto.Parameters.Add("@img", MySqlDbType.Binary, parent.image.Length);
                addPhoto.Parameters["@img"].Value = parent.image;
                addPhoto.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction("registrar", registrar);


            }
            else
                ModelState.AddModelError("Error", "Lütfen hataları gideriniz.");

            return View(parent);
        }
        public ActionResult createCourse(registrar registrar)
        {
            temp = registrar;
            return View();
        }
        [HttpPost]
        public ActionResult createCourse(course course)
        {
            if (ModelState.IsValid == true)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"insert into course(name) values('{course.name}');", conn);

                MySqlDataReader MyReader;
                MyReader = cmd.ExecuteReader();
                conn.Close();

                registrar registrar = new registrar();
                registrar = temp;
                temp = null;
                return RedirectToAction("registrar", registrar);


            }
            else
                ModelState.AddModelError("", "Lütfen hataları gideriniz.");

            return View(course);

        }
        public ActionResult addSection(registrar registrar)
        {
            List<string> p = new List<string>();
            MySqlDataReader MyReader;
            conn.Open();
            MySqlCommand command = new MySqlCommand($"select name from course;", conn);
            MyReader = command.ExecuteReader();
            while (MyReader.Read())
            {
                p.Add(MyReader["name"].ToString());
            }
            conn.Close();
            temp = registrar;
            section section = new section();
            section.course_names = p;
            return View(section);
        }
        [HttpPost]
        public ActionResult addSection(section section)
        {
            if (ModelState.IsValid == true)
            {
                string str = section.day + " " + section.hour;
                int temp_id = 0;
                MySqlDataReader MyReader;
                conn.Open();
                MySqlCommand command = new MySqlCommand($"select id from course where name='{section.course_name}';", conn);
                MyReader = command.ExecuteReader();
                while (MyReader.Read())
                {
                    temp_id = Convert.ToInt32(MyReader["id"]);
                }
                conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"insert into section(instructorId,courseId,date) values('{section.instructor_id}','{temp_id}','{str}');", conn);
                MyReader = cmd.ExecuteReader();
                conn.Close();

                registrar registrar = new registrar();
                registrar = temp;
                temp = null;
                return RedirectToAction("registrar", registrar);


            }
            else
                ModelState.AddModelError("", "Lütfen hataları gideriniz.");

            return View(section);

        }
        public static parent temp1 = new parent();
        public ActionResult addChild(parent parent)
        {
            temp1 = parent;
            return View();
        }
        [HttpPost]
        public ActionResult addChild(children children)
        {
            if (ModelState.IsValid == true)
            {
                MySqlDataReader MyReader;
                int temp_id = 0;
                conn.Open();
                MySqlCommand command = new MySqlCommand($"select id from parent where name='{temp1.name}' and surname='{temp1.surname}';", conn);
                MyReader = command.ExecuteReader();
                while (MyReader.Read())
                {
                    temp_id = Convert.ToInt32(MyReader["id"]);
                }
                conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"insert into children(parentId,studentId) values({temp_id},{children.student_id});", conn);


                MyReader = cmd.ExecuteReader();
                conn.Close();

                parent parent = new parent();
                parent = temp1;
                temp1 = null;
                return RedirectToAction("parent", parent);


            }
            else
                ModelState.AddModelError("", "Lütfen hataları gideriniz.");

            return View(children);

        }
        [HttpPost]
        public ActionResult getInstructor(string x)
        {
            List<instructor> i = new List<instructor>();
            string name = null;
            MySqlDataReader MyReader;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"select c.field from course c where name='{x}';", conn);
            MyReader = cmd.ExecuteReader();
            while (MyReader.Read())
            {
                name = MyReader["field"].ToString();
            }
            conn.Close();

            conn.Open();
            MySqlCommand command = new MySqlCommand($"select i.name,i.surname,i.id from instructor i where field='{name}';", conn);
            MyReader = command.ExecuteReader();
            while (MyReader.Read())
            {
                i.Add(new instructor() { name = MyReader["name"].ToString() + " " + MyReader["surname"].ToString(), id = Convert.ToInt32(MyReader["id"]) });
            }
            conn.Close();

            return Json(i, JsonRequestBehavior.AllowGet);

            //return name;
        }
        public ActionResult DeleteSection(registrar registrar)
        {
            conn.Open();
            MySqlDataReader my;
            MySqlCommand cmd = new MySqlCommand($"delete from section where id={registrar.section_id}", conn);
            my = cmd.ExecuteReader();
            conn.Close();
            return RedirectToAction("registrar", registrar);
        }
        //public static Dictionary<int, string> midterm_grade = new Dictionary<int, string>();
        //public static Dictionary<int, string> final_grade = new Dictionary<int, string>();
        //[HttpPost]
        //public void putDictionary(int id,string midterm)
        //{
        //    if (midterm_grade != null) {
        //        if (midterm != "") { 
        //    if (!midterm_grade.Keys.Contains(id))
        //    {
        //        midterm_grade.Add(id, midterm);
        //    }
        //        else
        //        {
        //            midterm_grade.Remove(id);
        //            midterm_grade.Add(id, midterm);

        //        }

        //    }}
        //}
        //[HttpPost]
        //public void putDictionary2(int id, string final)
        //{

        //    if (final_grade != null)
        //    {
        //        if (!final_grade.Keys.Contains(id))
        //        {
        //            final_grade.Add(id, final);
        //        }
        //        else
        //        {
        //            final_grade.Remove(id);
        //            final_grade.Add(id, final);

        //        }

        //    }
        //}
        [HttpPost]
        public void updateGrade(int section,List<changeGrade> midterm,List<changeGrade> final)
        {
            if (midterm != null)
            {
                foreach (changeGrade entry in midterm)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"update course_records set midterm={Convert.ToDouble(entry.grade)} where sectionId={section} and studentId={entry.id}", conn);
                    MySqlDataReader MyReader;
                    MyReader = cmd.ExecuteReader();
                    conn.Close();

                }
            }
            if (final != null) { 

            foreach (changeGrade entry in final)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"update course_records set final={Convert.ToDouble(entry.grade)} where sectionId={section} and studentId={entry.id}", conn);
                MySqlDataReader MyReader;
                MyReader = cmd.ExecuteReader();
                conn.Close();

            }
            }
      
        }
        public ActionResult addImage()
        {

            return View();
        }
        public void pass_fail(int section)
        {
            Dictionary<int,int> pass = new Dictionary<int, int>();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"select midterm,final,studentId from course_records where sectionId={section}", conn);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["midterm"] != DBNull.Value && reader["final"] != DBNull.Value) {
                    if ((Convert.ToDouble(reader["midterm"]) * 4 / 10 + Convert.ToDouble(reader["final"]) * 6 / 10) < 50)
                    {
                        pass.Add(Convert.ToInt32(reader["studentId"]),0);
                    }

                    else
                        pass.Add(Convert.ToInt32(reader["studentId"]),1);
                }
              
              
            }
            conn.Close();
            apply(pass, section);
            //conn.Open();
            //foreach(int x in pass) {
            //    MySqlCommand command;
            //    if (x != 3)
            //    {
            //        command= new MySqlCommand($"update course_records set isPassed = {x} where sectionId={section}", conn);
            //        MySqlDataReader dataReader;
            //        dataReader = command.ExecuteReader();
            //    }
                  
               
                   
            //}
            //conn.Close();
        }
      public void apply(Dictionary<int,int> pass,int section)
        {
            foreach (KeyValuePair<int,int> entry in pass)
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand($"update course_records set isPassed = {entry.Value} where sectionId={section} and studentId={entry.Key}", conn);
                MySqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                conn.Close();
            }
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
        

        public ActionResult retrieveImage()
        {
            byte[] data = null;

            student a = new student();
            conn.Open();
            MySqlCommand show = new MySqlCommand();
            show.Connection = conn;
            show.CommandText = $"SELECT image FROM student WHERE id=14";
            MySqlDataReader MyReader;
            MyReader = show.ExecuteReader();
            while (MyReader.Read())
            {
                data = (byte[])MyReader["image"];
            }

            conn.Close();
            a.image = data;
            
            return View(a);
        }
        public ActionResult displayImage(int section)
        {
            if (Session["ActiveUser"].ToString() == "instructor") { 
            int x = 0;
            byte[] data = null;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"select instructorId from section where id={section}", conn);
            MySqlDataReader my;
            my = cmd.ExecuteReader();
            while (my.Read())
            {
                x = Convert.ToInt32(my["instructorId"]);
            }
           
            conn.Close();
           
            
            conn.Open();
            MySqlCommand show = new MySqlCommand();
            show.Connection = conn;
            show.CommandText = $"SELECT image FROM instructor WHERE id={x}";
            MySqlDataReader MyReader;
            MyReader = show.ExecuteReader();
            while (MyReader.Read())
            {
                data = (byte[])MyReader["image"];
            }

            conn.Close();
            string str = Convert.ToBase64String(data);
            var str2= string.Format("data:image/jpg;base64,{0}", str);
            return Json(str,JsonRequestBehavior.AllowGet);}
            else if(Session["ActiveUser"].ToString() == "student")
            {
                
                byte[] data = null;
                


                conn.Open();
                MySqlCommand show = new MySqlCommand();
                show.Connection = conn;
                show.CommandText = $"SELECT image FROM student WHERE id={section}";
                MySqlDataReader MyReader;
                MyReader = show.ExecuteReader();
                while (MyReader.Read())
                {
                    data = (byte[])MyReader["image"];
                }

                conn.Close();
                string str = Convert.ToBase64String(data);
                var str2 = string.Format("data:image/jpg;base64,{0}", str);
                return Json(str, JsonRequestBehavior.AllowGet);
            }
            else if (Session["ActiveUser"].ToString() == "registrar")
            {

                byte[] data = null;



                conn.Open();
                MySqlCommand show = new MySqlCommand();
                show.Connection = conn;
                show.CommandText = $"SELECT image FROM registrar WHERE id={section}";
                MySqlDataReader MyReader;
                MyReader = show.ExecuteReader();
                while (MyReader.Read())
                {
                    data = (byte[])MyReader["image"];
                }

                conn.Close();
                string str = Convert.ToBase64String(data);
                var str2 = string.Format("data:image/jpg;base64,{0}", str);
                return Json(str, JsonRequestBehavior.AllowGet);
            }
            else
            {

                byte[] data = null;



                conn.Open();
                MySqlCommand show = new MySqlCommand();
                show.Connection = conn;
                show.CommandText = $"SELECT image FROM parent WHERE id={section}";
                MySqlDataReader MyReader;
                MyReader = show.ExecuteReader();
                while (MyReader.Read())
                {
                    data = (byte[])MyReader["image"];
                }

                conn.Close();
                string str = Convert.ToBase64String(data);
                var str2 = string.Format("data:image/jpg;base64,{0}", str);
                return Json(str, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult displayImage2(int section)
        {


            byte[] data = null;

            conn.Open();
                MySqlCommand show = new MySqlCommand();
                show.Connection = conn;
                show.CommandText = $"SELECT image FROM instructor WHERE id={section}";
                MySqlDataReader MyReader;
                MyReader = show.ExecuteReader();
                while (MyReader.Read())
                {
                    data = (byte[])MyReader["image"];
                }

                conn.Close();
                string str = Convert.ToBase64String(data);
                var str2 = string.Format("data:image/jpg;base64,{0}", str);
                return Json(str, JsonRequestBehavior.AllowGet);
            }

        }


}