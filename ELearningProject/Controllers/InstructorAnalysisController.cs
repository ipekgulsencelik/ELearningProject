﻿using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            // int id = 9;
            var instructor = context.Instructors.Where(x => x.InstructorID == id).ToList();

            // var instructor = context.Instructors.Where(x => x.Name == "Ahmet" && x.Surname == "Ölçen").Select(y => y.InstructorID).FirstOrDefault();

            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == id).Count();

            var courseList = context.Courses.Where(x => x.InstructorID == id).Select(y => y.CourseID).ToList();

            ViewBag.commentCount = context.Comments.Where(x => courseList.Contains(x.CourseID)).Count();

            ViewBag.averageReviewScore = context.Reviews.Where(x => courseList.Contains(x.CourseID)).Average(x => x.ReviewScore);

            return PartialView(instructor);
        }

        public PartialViewResult _ContactPartial()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            var instructor = context.Instructors.Where(x => x.InstructorID == id).FirstOrDefault();

            return PartialView(instructor);
        }

        public PartialViewResult _CommentPartial()
        {
            // select InstructorID from Instructors where Name='Ahmet' and Surname='Ölçen' = instructor
            // var instructor = context.Instructors.Where(x => x.Name == "Ahmet" && x.Surname == "Ölçen").Select(y => y.InstructorID).FirstOrDefault();

            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            
            var instructor = context.Instructors.Where(x => x.InstructorID == id).ToList();

            // select CourseID from Courses where InstructorID = courseList
            var courseList = context.Courses.Where(x => x.InstructorID == id).Select(y => y.CourseID).ToList();

            // select * from Comments where CourseID In ...
            var commentList = context.Comments.Where(x => courseList.Contains(x.CourseID)).ToList();

            return PartialView(commentList);
        }

        public PartialViewResult _CourseListByInstructorPartial()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();

            var courses = context.Courses.Where(x => x.InstructorID == id).ToList();

            return PartialView(courses);
        }

        public ActionResult MyCourse()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();

            var courses = context.Courses.Where(x => x.InstructorID == id).ToList();

            return View(courses);
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.category = categories;

            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course, System.Web.HttpPostedFileBase image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                course.ImageURL = uniqueFileName;
            }

            if (Request.Form["Status"] != null)
            {
                string status = Request.Form["Status"]; 
            }
            else
            {
                course.Status = false;
            }

            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            course.InstructorID = id;

            course.IsHome = false;
            course.IsPopular = false;

            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("MyCourse");
        }

        public ActionResult DeleteCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("MyCourse");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.category = categories;

            var value = context.Courses.Find(id);

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course, System.Web.HttpPostedFileBase image)
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(x => x.InstructorID).FirstOrDefault();

            var value = context.Courses.Find(course.CourseID);

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                course.ImageURL = uniqueFileName;
                value.ImageURL = course.ImageURL;
            }
            else
            {
                value.ImageURL = value.ImageURL;
            }

            value.Title = course.Title;
            value.Description = course.Description;
            value.CategoryID = course.CategoryID;
            value.Duration = course.Duration;
            value.Price = course.Price;
            value.InstructorID = id;
            value.IsHome = false;
            value.IsPopular = false;
            value.Status = course.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetReview(int id)
        {
            ViewBag.averageReviewScore = context.Reviews.Where(x => x.CourseID == id).Average(x => x.ReviewScore);
           
            return View();
        }


        public ActionResult GetComment(int id)
        {
            var comments = context.Comments.Where(x => x.CourseID == id).ToList();
            if (comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.comments = comments;

            return View();
        }

        public ActionResult CourseDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = context.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseId = id;

            var comments = context.Comments.Where(x => x.CourseID.Equals(id.Value)).ToList();
            ViewBag.comments = comments;

            var ratings = context.Reviews.Where(x => x.CourseID.Equals(id.Value)).ToList();
            ViewBag.ratings = ratings;
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(x => x.ReviewScore);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(course);
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            var instructor = context.Instructors.Where(x => x.InstructorID == id).FirstOrDefault();

            return View(instructor);
        }

        [HttpPost]
        public ActionResult MyProfile(Instructor instructor, System.Web.HttpPostedFileBase image)
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            var value = context.Instructors.Where(x => x.InstructorID == id).FirstOrDefault();

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                instructor.ImageURL = uniqueFileName;
                value.ImageURL = instructor.ImageURL;
            }
            else
            {
                value.ImageURL = value.ImageURL;
            }

            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
            value.Email = instructor.Email;
            value.PhoneNumber = instructor.PhoneNumber;
            if (instructor.Password == null)
            {
                value.Password = value.Password;
                value.ConfirmPassword = value.ConfirmPassword;
            }
            else
            {
                value.Password = instructor.Password;
                value.ConfirmPassword = instructor.ConfirmPassword;
            }
            context.SaveChanges();
            return RedirectToAction("LoginInstructor", "Login");
        }     

        [HttpGet]
        public ActionResult AddVideo(int id)
        {
            ViewBag.id = id;
            ViewBag.courseName = context.Courses.Where(x => x.CourseID == id).Select(x => x.Title).FirstOrDefault();
            var values = context.Videos.Where(x => x.CourseID == id).ToList();

            return View(values);
        }

        [HttpPost]
        public ActionResult AddVideo(Video video)
        {
            context.Videos.Add(video);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}