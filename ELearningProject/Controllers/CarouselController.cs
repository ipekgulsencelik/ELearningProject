using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class CarouselController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Carousels.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCarousel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCarousel(Carousel carousel, System.Web.HttpPostedFileBase image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                carousel.ImageURL = uniqueFileName;
            }

            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                carousel.Status = false;
            }

            context.Carousels.Add(carousel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCarousel(int id)
        {
            var value = context.Carousels.Find(id);
            context.Carousels.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCarousel(int id)
        {
            var value = context.Carousels.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCarousel(Carousel carousel, System.Web.HttpPostedFileBase image)
        {
            var value = context.Carousels.Find(carousel.CarouselID);

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                carousel.ImageURL = uniqueFileName;
            }

            value.Title = carousel.Title;
            value.SubTitle = carousel.SubTitle;
            value.Description = carousel.Description;
            value.ImageURL = carousel.ImageURL;
            value.Status = carousel.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}