using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class CategoryController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            //string mail = Session["CurrentMail"].ToString();
            if (!string.IsNullOrEmpty(Session["CurrentMail"].ToString()))
            {
                string mail = Session["CurrentMail"].ToString();
                if (context.Admins.Where(x => x.Email == mail).Count() >= 0)
                {
                    var values = context.Categories.ToList();
                    return View(values);
                }
                else
                {
                    return RedirectToAction("Index", "Error");
                }
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category, System.Web.HttpPostedFileBase image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                category.ImageURL = uniqueFileName;
            }

            if (Request.Form["IsHome"] != null)
            {
                string isHome = Request.Form["IsHome"];
            }
            else
            {
                category.IsHome = false;
            }

            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                category.Status = false;
            }

            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category, System.Web.HttpPostedFileBase image)
        {
            var value = context.Categories.Find(category.CategoryID);

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                category.ImageURL = uniqueFileName; 
                value.ImageURL = category.ImageURL;
            }
            else
            {
                value.ImageURL = value.ImageURL;
            }

            value.CategoryName = category.CategoryName;
            value.IsHome = category.IsHome;
            value.Status = category.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}