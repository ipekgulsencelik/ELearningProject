using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class CommentController : Controller
    {
        ELearningContext context = new ELearningContext();

        // GET: Comment
        public ActionResult Index()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var comments = context.Comments.Where(x => x.StudentID == id).ToList();
            return View(comments);
        }

        [HttpGet]
        public ActionResult CreateComment()
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
        public ActionResult CreateComment(Comment comment)
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();

            comment.CommentStatus = true;
            comment.CommentDate = DateTime.Now;
            comment.StudentID = id;
            context.Comments.Add(comment);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteComment(int id)
        {
            var value = context.Comments.Find(id);
            context.Comments.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateComment(int id)
        {
            string values = Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var course = context.Courses.ToList();
            List<SelectListItem> courseList = (from x in course
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.CourseID.ToString()
                                               }).ToList();
            ViewBag.course = courseList;
           
            var value = context.Comments.Find(id);

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateComment(Comment comment)
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();

            var value = context.Comments.Find(comment.CommentID);
                       
            value.CommentText = comment.CommentText;
            value.CourseID = comment.CourseID;
            value.StudentID = id;
            value.CommentDate = DateTime.Now;
            value.CommentStatus = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}