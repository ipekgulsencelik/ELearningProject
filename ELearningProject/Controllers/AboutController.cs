using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class AboutController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutID);
            value.Title = about.Title;
            value.Description = about.Description;
            value.SubDescription = about.SubDescription;
            value.ImageURL = about.ImageURL;
            value.Status = about.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}