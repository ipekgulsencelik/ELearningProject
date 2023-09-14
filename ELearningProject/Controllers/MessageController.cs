using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class MessageController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Messages.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMessage(Message message)
        {
            var value = context.Messages.Find(message.MessageID);
            value.NameSurname = message.NameSurname;
            value.EMail = message.EMail;
            value.Subject = message.Subject;
            value.Content = message.Content;
            value.Status = message.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}