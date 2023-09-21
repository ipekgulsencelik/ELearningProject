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

            instructor.CoverImage = uniqueFileName;

            if (Request.Form["IsHome"] != null)
            {
                string isHome = Request.Form["IsHome"];
            }
            else
            {
                instructor.IsHome = false;
            }

            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                instructor.Status = false;
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
                value.ImageURL = instructor.ImageURL;
                value.CoverImage = instructor.ImageURL;
            }
            else
            {
                value.ImageURL = value.ImageURL;
                value.CoverImage = value.ImageURL;
            }

            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
            value.Title = instructor.Title;
            value.SocialMedia1 = instructor.SocialMedia1;
            value.SocialMedia2 = instructor.SocialMedia2;
            value.SocialMedia3 = instructor.SocialMedia3;
            value.IsHome = instructor.IsHome;
            value.Status = instructor.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}