using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class ProfileController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            string values = Session["CurrentMail"].ToString();
            ViewBag.mail = Session["CurrentMail"];
            ViewBag.name = context.Students.Where(x => x.Email == values).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
        
            return View();
        }

        public ActionResult MyCourseList()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
            
            return View(courseList);
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var student = context.Students.Where(x => x.StudentID == id).FirstOrDefault();

            return View(student);
        }

        [HttpPost]
        public ActionResult MyProfile(Student student, System.Web.HttpPostedFileBase image)
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var value = context.Students.Where(x => x.StudentID == id).FirstOrDefault();

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                student.ImageURL = uniqueFileName;
                value.ImageURL = student.ImageURL;
            }
            else
            {
                value.ImageURL = value.ImageURL;
            }

            value.Name = student.Name;
            value.Surname = student.Surname;
            value.Email = student.Email;
            value.PhoneNumber = student.PhoneNumber;
            value.Password = student.Password;
            value.ConfirmPassword = student.ConfirmPassword;
            context.SaveChanges();
            return RedirectToAction("LoginStudent", "Login");
        }

        [HttpGet]
        public ActionResult AddReview(int id) 
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddReview(Review review, int id)
        {
            string values = Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            review.StudentID = studentID;
            review.CourseID = id;

            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment, int id)
        {
            string values = Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            comment.StudentID = studentID;
            comment.CommentStatus = true;
            comment.CourseID = id;
            comment.CommentDate = DateTime.Now;
            context.Comments.Add(comment);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}