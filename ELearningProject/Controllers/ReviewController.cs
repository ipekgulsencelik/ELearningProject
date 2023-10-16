using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class ReviewController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: Review
        [HttpGet]
        public ActionResult Index()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var course = context.Courses.ToList();
            List<SelectListItem> courseList = (from x in course
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.CourseID.ToString()
                                               }).ToList();
            ViewBag.course = courseList;

            return View();
        }

        [HttpPost]
        public ActionResult Index(Review review)
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            review.StudentID = id;

            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }
    }
}