using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class ServiceController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            ViewBag.breadcrumb = "Hizmet";
            var values = context.Services.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService() { return View(); }

        [HttpPost]
        public ActionResult AddService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var value = context.Services.Find(id);
            context.Services.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Services.Find(service.ServiceID);
            value.Icon = service.Icon;
            value.Title = service.Title;
            value.Description = service.Description;
            value.Status = service.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}