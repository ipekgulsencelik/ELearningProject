using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class StudentController : Controller
    {
        ELearningContext context = new ELearningContext();
        
        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student, System.Web.HttpPostedFileBase image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                student.ImageURL = uniqueFileName;
            }

            if (Request.Form["Status"] != null)
            {
                string status = Request.Form["Status"];
            }
            else
            {
                student.Status = false;
            }

            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var value = context.Students.Find(id);
            context.Students.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var value = context.Students.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student, System.Web.HttpPostedFileBase image)
        {
            var value = context.Students.Find(student.StudentID);

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                student.ImageURL = uniqueFileName;
                value.ImageURL = student.ImageURL;
            }
            else
            {
                value.ImageURL = value.ImageURL;
            }

            value.Name = student.Name;
            value.Surname = student.Surname;
            value.Email = student.Email;
            value.PhoneNumber = student.PhoneNumber;
            if (student.Password == null)
            {
                value.Password = value.Password;
                value.ConfirmPassword = value.ConfirmPassword;
            }
            else
            {
                value.Password = student.Password;
                value.ConfirmPassword = student.ConfirmPassword;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}