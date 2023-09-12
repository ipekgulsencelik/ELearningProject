using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
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