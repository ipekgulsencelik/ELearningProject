using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class StudentPanelController : Controller
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