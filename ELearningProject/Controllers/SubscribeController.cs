using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class SubscribeController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Subscribes.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSubscribe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubscribe(Subscribe subscribe)
        {
            context.Subscribes.Add(subscribe);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSubscribe(int id)
        {
            var value = context.Subscribes.Find(id);
            context.Subscribes.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSubscribe(int id)
        {
            var value = context.Subscribes.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSubscribe(Subscribe subscribe)
        {
            var value = context.Subscribes.Find(subscribe.SubscribeID);
            value.Mail = subscribe.Mail;
            value.Status = subscribe.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}