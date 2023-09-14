using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using ELearningProject.Models;
using MimeKit;
using System.Linq;
using System.Web.Mvc;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

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
            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                subscribe.Status = false;
            }

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

        [HttpGet]
        public ActionResult SendMailToSubscriber(int id)
        {
            var value = context.Subscribes.Find(id);
            ViewBag.mail = value.Mail;
            ViewBag.name = "Sevgili Abonemiz";
            ViewBag.subject = "Abone Bülteni";
            return View();
        }

        [HttpPost]
        public ActionResult SendMailToSubscriber(MailRequest mail)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("E-Learning Admin", "celik.ipekgulsen@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress(mail.ReceiverName, mail.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mail.Body;

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = mail.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("celik.ipekgulsen@gmail.com", "idekglamodhssdrb");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index");
        }
    }
}