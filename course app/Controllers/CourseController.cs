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
            return View();
            

        }
        
        [HttpPost]
        public ActionResult Login(login a)
        {
            List<string> user=new List<string>();
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
                student.name=user[1];
                student.surname = user[2];
                student.gender = user[3];
                student.age = Convert.ToInt32(user[4]);
                student.email = user[5];
                student.password = user[6];
                return RedirectToAction("student", student);
              //  return View(student);

            }
            else if (str == "instructor")
                return View("instructor");
            else if (str == "registrar")
                return View("registrar");

            else
                return RedirectToAction("parent");
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
        public ActionResult instructor()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult instructor(string str)
        {
            return View();
        }
        public ActionResult registrar()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult registrar(string str)
        {
            return View();
        }
        public ActionResult parent()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult parent(string str)
        {
            return View();
        }
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
       
        
        public ActionResult addCourse()
        {
            return View();
        }
        public ActionResult grades()
        {
            return View();
        }
        public ActionResult showStudent()
        {
            return View();
        }

        public ActionResult addImage()
        {
            
            return View();
        }
        [HttpPost]

        public ActionResult addImage(student a,HttpPostedFileBase image1)
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
            byte[] data= null;
            
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