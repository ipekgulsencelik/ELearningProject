using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class InstructorAnlysisController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _InstructorPanelPartial(int id)
        {
            id = 1;
            var values = context.Instructors.Where(x => x.InstructorID == id).ToList();
            return PartialView(values);
        }

        public PartialViewResult _CommentPartial()
        {
            return PartialView();
        }
    }
}