using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            List<SelectListItem> instructors = (from y in context.Instructors.ToList().OrderBy(z => z.Name)
                                                select new SelectListItem
                                                {
                                                    Text = y.Name + " " + y.Surname,
                                                    Value = y.InstructorID.ToString()
                                                }).ToList();
            ViewBag.instructor = instructors;

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

            if (Request.Form["IsPopular"] != null)
            {
                string isPopular = Request.Form["IsPopular"];
            }
            else
            {
                course.IsPopular = false;
            }

            if (Request.Form["IsHome"] != null)
            {
                string isHome = Request.Form["IsHome"];
            }
            else
            {
                course.IsHome = false;
            }

            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                course.Status = false;
            }

            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
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


            List<SelectListItem> instructors = (from y in context.Instructors.ToList().OrderBy(z => z.Name)
                                                select new SelectListItem
                                                {
                                                    Text = y.Name + " " + y.Surname,
                                                    Value = y.InstructorID.ToString()
                                                }).ToList();
            ViewBag.instructor = instructors;

            var value = context.Courses.Find(id);

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course, System.Web.HttpPostedFileBase image)
        {
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
            value.InstructorID = course.InstructorID;
            value.IsHome = course.IsHome;
            value.IsPopular = course.IsPopular;
            value.Status = course.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
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
            ViewBag.courseId = id.Value;

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
    }
}