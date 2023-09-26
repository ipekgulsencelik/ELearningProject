using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class TestimonialPageController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: TestimonialPage
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _TestimonialPartial()
        {
            var values = context.Testimonials.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
    }
}