using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class CourseController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Courses.ToList();
            return View(values);
        }
    }
}