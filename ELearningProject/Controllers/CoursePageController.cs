using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ELearningProject.Controllers
{
    public class CoursePageController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: CoursePage
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CategoryPartial()
        {
            var values = context.Categories.Where(x => x.Status == true).ToList();

            return PartialView(values);
        }

        public PartialViewResult _CoursePartial(int page = 1)
        {
            var values = context.Courses.Where(x => x.Status == true && x.IsPopular == true).OrderByDescending(y => y.CourseID).ToList().ToPagedList(page, 3);
            return PartialView(values);
        }
    }
}