using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;

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

        public PartialViewResult _BreadcrumbPartial()
        {
            return PartialView();
        }

        public PartialViewResult _ServicePartial()
        {
            var values = context.Services.Where(x => x.Status == true && x.IsHome == true).OrderByDescending(x => x.ServiceID).Take(4).ToList(); 
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
            var values = context.Categories.Where(x => x.IsHome == true && x.Status == true).Take(4).ToList();

            var category1 = values[0].CategoryID;
            ViewBag.courseCount1 = context.Courses.Where(x => x.Status == true && x.CategoryID == category1).Count();

            var category2 = values[1].CategoryID;
            ViewBag.courseCount2 = context.Courses.Where(x => x.Status == true && x.CategoryID == category2).Count();

            var category3 = values[2].CategoryID;
            ViewBag.courseCount3 = context.Courses.Where(x => x.Status == true && x.CategoryID == category3).Count();

            var category4 = values[3].CategoryID;
            ViewBag.courseCount4 = context.Courses.Where(x => x.Status == true && x.CategoryID == category4).Count();

            return PartialView(values);
        }

        public PartialViewResult _CoursePartial()
        {
            var values = context.Courses.Where(x => x.Status == true && x.IsHome == true && x.IsPopular == true).OrderByDescending(y => y.CourseID).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult _TeamPartial()
        {
            var values = context.Instructors.Where(x => x.Status == true && x.IsHome == true).OrderByDescending(x => x.InstructorID).Take(4).ToList();
            return PartialView(values);
        }

        public PartialViewResult _TestimonialPartial()
        {
            var values = context.Testimonials.Where(x => x.Status == true && x.IsHome == true).OrderByDescending(x => x.TestimonialID).Take(4).ToList();
            return PartialView(values);
        }

        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult _GalleryPartial()
        {
            return PartialView();
        }

        public PartialViewResult _ContactPartial()
        {
            var value = context.ContactInfos.OrderByDescending(x => x.ContactInfoID).Where(x => x.Status == true).FirstOrDefault();
            return PartialView(value);
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult _SubscribePartial(Subscribe subscribe)
        {
            subscribe.Status = true;
            context.Subscribes.Add(subscribe);
            context.SaveChanges();
            return PartialView();
        }
    }
}