using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult _SpinnerPartial()
        {
            return PartialView();
        }

        public PartialViewResult _CarouselPartial()
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

        public PartialViewResult _ServicePartial()
        {
            return PartialView();
        }

        public PartialViewResult _AboutPartial()
        {
            return PartialView();
        }

        public PartialViewResult _CategoryPartial()
        {
            return PartialView();
        }

        public PartialViewResult _CoursePartial()
        {
            return PartialView();
        }

        public PartialViewResult _TeamPartial()
        {
            return PartialView();
        }

        public PartialViewResult _TestimonialPartial()
        {
            return PartialView();
        }

        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
    }
}