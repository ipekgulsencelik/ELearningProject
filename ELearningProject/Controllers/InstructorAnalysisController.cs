using ELearningProject.DAL.Context;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _InstructorPanelPartial()
        {
            int id = 9;
            var values = context.Instructors.Where(x => x.InstructorID == id).ToList();
            return PartialView(values);
        }

        public PartialViewResult _CommentPartial()
        {
            // select InstructorID from Instructors where Name='Ahmet' and Surname='Ölçen' = instructor
            var instructor = context.Instructors.Where(x => x.Name == "Ahmet" && x.Surname == "Ölçen").Select(y => y.InstructorID).FirstOrDefault();

            // select CourseID from Courses where InstructorID = courseList
            var courseList = context.Courses.Where(x => x.InstructorID == instructor).Select(y => y.CourseID).ToList();

            // select * from Comments where CourseID In ...
            var commentList = context.Comments.Where(x => courseList.Contains(x.CourseID)).ToList();

            return PartialView(commentList);
        }

        public PartialViewResult _CourseListByInstructorPartial()
        {
            var values = context.Courses.Where(x => x.InstructorID == 9).ToList();
            return PartialView(values);
        }
    }
}