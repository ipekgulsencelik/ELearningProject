using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class StudentPanelController : Controller
    {
        ELearningContext context = new ELearningContext();

        public PartialViewResult _NavbarPartial()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(x => x.StudentID).FirstOrDefault();

            var student = context.Students.Where(x => x.StudentID == id).FirstOrDefault();

            ViewBag.image = student.ImageURL;
            ViewBag.name = student.Name + " " + student.Surname;

            return PartialView();
        }

        public PartialViewResult _SidebarPartial()
        {
            return PartialView();
        }
    }
}