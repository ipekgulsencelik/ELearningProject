using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class DefaultController : Controller
    {
        ELearningContext context = new ELearningContext();

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
            var values = context.Carousels.ToList();
            return PartialView(values);
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
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult _AboutPartial()
        {
            var value = context.Abouts.OrderByDescending(x => x.AboutID).FirstOrDefault();

            ViewBag.image = value.ImageURL;
            ViewBag.title = value.Title;
            ViewBag.description = value.Description;
            ViewBag.subDescription = value.SubDescription;

            var values = context.AboutItems.ToList();

            return PartialView(values);
        }

        public PartialViewResult _CategoryPartial()
        {
            var values = context.Categories.Where(x => x.IsHome == true).Take(4).ToList();
            return PartialView(values);
        }

        public PartialViewResult _CoursePartial()
        {
            var values = context.Courses.Where(x => x.Status == true && x.IsHome == true && x.IsPopular == true).OrderByDescending(y => y.CourseID).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult _TeamPartial()
        {
            var values = context.Instructors
                .Where(x =>
                            x.Status == true &&
                            x.IsHome == true)
                .OrderByDescending(y =>
                                   y.InstructorID)
                .Take(4)
                .ToList();
            return PartialView(values);
        }

        public PartialViewResult _TestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
    }
}