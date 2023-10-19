using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Admins.Where(x => x.Email == values).Select(x => x.AdminID).FirstOrDefault();
            var admin = context.Admins.Where(x => x.AdminID == id).FirstOrDefault();

            return View(admin);
        }

        [HttpPost]
        public ActionResult MyProfile(Admin model, System.Web.HttpPostedFileBase image)
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Admins.Where(x => x.Email == values).Select(x => x.AdminID).FirstOrDefault();
            var admin = context.Admins.Where(x => x.AdminID == id).FirstOrDefault();

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                model.ImageURL = uniqueFileName;
                admin.ImageURL = model.ImageURL;
            }
            else
            {
                model.ImageURL = model.ImageURL;
            }

            admin.Name = model.Name;
            admin.Surname = model.Surname;
            admin.Email = model.Email;
            admin.PhoneNumber = model.PhoneNumber;
            if (model.Password == null)
            {
                admin.Password = admin.Password;
                admin.ConfirmPassword = admin.ConfirmPassword;
            }
            else
            {
                admin.Password = model.Password;
                admin.ConfirmPassword = model.ConfirmPassword;
            }
            context.SaveChanges();
            return RedirectToAction("LoginAdmin", "Login");
        }

        public PartialViewResult _HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult _SidebarPartial()
        {
            return PartialView();
        }

        public PartialViewResult _ScriptPartial()
        {
            return PartialView();
        }

        public PartialViewResult _NavbarPartial()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Admins.Where(x => x.Email == values).Select(x => x.AdminID).FirstOrDefault();

            var admin = context.Admins.Where(x => x.AdminID == id).FirstOrDefault();

            ViewBag.image = admin.ImageURL;
            ViewBag.name = admin.Name + " " + admin.Surname;

            return PartialView();
        }

        public PartialViewResult _PageRowTitlePartial()
        {
            return PartialView();
        }

        public PartialViewResult _PreloaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
    }
}