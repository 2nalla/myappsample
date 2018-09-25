using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgStudentGradesSpa1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult StudentsGrades()
        {
            return View();
        }

        public ActionResult SearchStudent()
        {
            return View();
        }

        public ActionResult StudentHome()
        {
            ViewBag.MyDateTime = DateTime.Now;
            return View();
        }
    }
}