using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class TestimonialController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial() { return View(); }

        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial, System.Web.HttpPostedFileBase image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                testimonial.ImageURL = uniqueFileName;
            }

            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                testimonial.Status = false;
            }

            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial, System.Web.HttpPostedFileBase image)
        {
            var value = context.Testimonials.Find(testimonial.TestimonialID);

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                testimonial.ImageURL = uniqueFileName; 
                value.ImageURL = testimonial.ImageURL;
            }
            else
            {
                value.ImageURL = value.ImageURL;
            }

            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.Comment = testimonial.Comment;
            value.Status = testimonial.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}