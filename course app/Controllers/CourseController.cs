using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using course_app.Models;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
                return View("student");
            else if (str == "instructor")
                return View("instructor");
            else if (str == "registrar")
                return View("registrar");

            else
                return View("parent");
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


        public ActionResult student()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult student(string str)
        {
            return View();
        }
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
        public ActionResult info()
        {
            return View();
                
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
    }
}