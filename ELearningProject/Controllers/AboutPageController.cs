using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class AboutPageController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: AboutPage
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ServicePartial()
        {
            var values = context.Services.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
    }
}