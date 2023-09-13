using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class ContactInfoController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.ContactInfos.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContactInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContactInfo(ContactInfo contact)
        {
            context.ContactInfos.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContactInfo(int id)
        {
            var value = context.ContactInfos.Find(id);
            context.ContactInfos.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContactInfo(int id)
        {
            var value = context.ContactInfos.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContactInfo(ContactInfo contact)
        {
            var value = context.ContactInfos.Find(contact.ContactInfoID);
            value.Address = contact.Address;
            value.Phone = contact.Phone;
            value.Email = contact.Email;        
            value.Status = contact.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}