using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class ContactPageController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: ContactPage
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ContactInfoPartial() 
        {
            var value = context.ContactInfos.OrderByDescending(x => x.ContactInfoID).Where(x => x.Status == true).FirstOrDefault();
            return PartialView(value);
        }

        public PartialViewResult _MapPartial()
        {
            var value = context.Maps.OrderByDescending(x => x.MapID).Where(x => x.Status == true).FirstOrDefault();
            return PartialView(value);
        }

        [HttpGet]
        public PartialViewResult _SendMessagePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult _SendMessagePartial(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return PartialView();
        }
    }
}