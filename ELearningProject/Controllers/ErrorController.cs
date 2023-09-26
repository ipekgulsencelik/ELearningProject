using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _404Partial()
        {
            return PartialView();
        }
    }
}