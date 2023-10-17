using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ELearningProject.Controllers
{
    public class LoginController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.Email == admin.Email && x.Password == admin.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Course");
            }
            return View();
        }

        [HttpGet]
        public ActionResult LoginInstructor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginInstructor(Instructor instructor)
        {
            var values = context.Instructors.FirstOrDefault(x => x.Email == instructor.Email && x.Password == instructor.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "InstructorAnalysis");
            }
            return View();
        }

        [HttpGet]
        public ActionResult LoginStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginStudent(Student student)
        {
            var values = context.Students.FirstOrDefault(x => x.Email == student.Email && x.Password == student.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}