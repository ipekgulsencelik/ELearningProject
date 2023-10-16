using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class InstructorPanelController : Controller
    {
        ELearningContext context = new ELearningContext();

        public PartialViewResult _NavbarPartial()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();

            var instructor = context.Instructors.Where(x => x.InstructorID == id).FirstOrDefault();

            ViewBag.image = instructor.ImageURL;
            ViewBag.name = instructor.Name + " " + instructor.Surname;

            return PartialView();
        }

        public PartialViewResult _SidebarPartial()
        {
            return PartialView();
        }
    }
}