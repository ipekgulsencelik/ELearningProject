using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eLearningProject.Controllers
{
    public class InstructorController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Instructors.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInstructor() { return View(); }

        [HttpPost]
        public ActionResult AddInstructor(Instructor instructor, System.Web.HttpPostedFileBase image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                instructor.ImageURL = uniqueFileName;
            }
            
            context.Instructors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInstructor(int id)
        {
            var value = context.Instructors.Find(id);
            context.Instructors.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInstructor(int id)
        {
            var value = context.Instructors.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInstructor(Instructor instructor, System.Web.HttpPostedFileBase image)
        {
            var value = context.Instructors.Find(instructor.InstructorID);

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                instructor.ImageURL = uniqueFileName;
            }

            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
            value.ImageURL = instructor.ImageURL;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}