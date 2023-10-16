using ELearningProject.DAL.Context;
using ELearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class RoleAssignController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: RoleAssign
        public ActionResult Index()
        {
            var values = context.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AssignRole(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.UserID == id);
            TempData["userId"] = user.UserID;

            var roles = context.Roles.ToList();
            var roleId = context.UserRoles.Where(x => x.UserID == user.UserID).Select(x => x.Role);
            var userRoles = (from userRole in context.UserRoles
                         join role in context.Roles on userRole.RoleID
                         equals role.RoleID where role.RoleID.Equals(roleId)
                         select role.RoleName).ToList();
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleID = item.RoleID;
                model.RoleName = item.RoleName;
                model.RoleExist = userRoles.Contains(item.RoleName);
                roleAssignViewModels.Add(model);
            }
            return View(roleAssignViewModels);
        }

        [HttpPost]
        public ActionResult AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int)TempData["userId"];
            var user = context.Users.FirstOrDefault(x => x.UserID == userId);
            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    //AddToRole(user, item.RoleName);
                }
                else
                {
                    //RemoveFromRole(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}