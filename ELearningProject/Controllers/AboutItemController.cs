using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class AboutItemController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.AboutItems.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAboutItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAboutItem(AboutItem item)
        {
            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                item.Status = false;
            }

            context.AboutItems.Add(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAboutItem(int id)
        {
            var value = context.AboutItems.Find(id);
            context.AboutItems.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAboutItem(int id)
        {
            var value = context.AboutItems.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAboutItem(AboutItem item)
        {
            var value = context.AboutItems.Find(item.AboutItemID);
            value.ItemName = item.ItemName;
            value.Status = item.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}