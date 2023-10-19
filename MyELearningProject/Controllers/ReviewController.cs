using MyELearningProject.DAL.Context;
using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class ReviewController : Controller
    {
        ELearningContext context=new ELearningContext();

        public ActionResult Index()
        {
            string value = Session["StudentCurrentMail"].ToString();

            var id=context.Students.Where(x=>x.Email== value).Select(x=>x.StudentID).FirstOrDefault();

            ViewBag.Id = id;
            var courseIds = context.Processes.Where(x=>x.StudentID== id).ToList().Select(y => y.CourseID);
            List<SelectListItem> courses = new List<SelectListItem>();

            foreach (var courseId in courseIds)
            {
                var course = context.Courses.FirstOrDefault(c => c.CourseID == courseId);
                courses.Add(new SelectListItem
                {
                    Text = course.Title,
                    Value = course.CourseID.ToString()
                });
            }

            ViewBag.v = courses;

            return View();
        }

        [HttpPost]  

        public ActionResult Index(Review review)        
        {
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index","ProfileStudent");

        }
    }
}