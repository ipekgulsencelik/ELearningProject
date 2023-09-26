using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class TeamPageController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: TeamPage
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _TeamPartial()
        {
            var values = context.Instructors.Where(x => x.Status == true).OrderByDescending(x => x.InstructorID).ToList();
            return PartialView(values);
        }
    }
}