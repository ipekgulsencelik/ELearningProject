using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class InstructorPanelController : Controller
    {
        public PartialViewResult _NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult _SidebarPartial()
        {
            return PartialView();
        }
    }
}