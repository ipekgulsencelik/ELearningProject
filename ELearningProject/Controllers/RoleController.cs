using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class RoleController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            var result = context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRole(int id)
        {
            var value = context.Roles.Find(id);
            context.Roles.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateRole(int id)
        {
            var value = context.Roles.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateRole(Role role)
        {
            var value = context.Roles.Find(role.RoleID);
            value.RoleName = role.RoleName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}