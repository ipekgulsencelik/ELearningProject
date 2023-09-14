using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class MapController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Maps.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddMap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMap(Map map)
        {
            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                map.Status = false;
            }

            context.Maps.Add(map);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMap(int id)
        {
            var value = context.Maps.Find(id);
            context.Maps.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMap(int id)
        {
            var value = context.Maps.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMap(Map map)
        {
            var value = context.Maps.Find(map.MapID);
            value.LocationURL = map.LocationURL;
            value.Status = map.Status;            
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}