using MyELearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class DefaultController : Controller
    {
        ELearningContext context = new ELearningContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {

            return PartialView();
        }

        public PartialViewResult PartialNavBar()
        {

            return PartialView();
        }

        public PartialViewResult PartialSlider()
        {

            return PartialView();
        }

        public PartialViewResult PartialService()
        {
            var values=context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var value=context.Abouts.FirstOrDefault();

            return PartialView(value);
        }

        public PartialViewResult PartialCategory()
        {
  
            var values=context.Categories.ToList(); 

            return PartialView(values);
        }

        public PartialViewResult PartialCourse()
        {
            var starAverage0=context.Reviews.Where(x=>x.CourseID==29).Select(x=>x.ReviewScore).Average();

            ViewBag.starCount0=starAverage0;

            var starAverage1 = context.Reviews.Where(x => x.CourseID == 30).Select(x => x.ReviewScore).Average();

            ViewBag.starCount1 = starAverage1;

            var starAverage2 = context.Reviews.Where(x => x.CourseID == 31).Select(x => x.ReviewScore).Average();

            ViewBag.starCount2 = starAverage2;




            var countReviewUniqueStudents=context.Reviews.Select(x=>x.StudentID).Distinct().Count();

            ViewBag.count = countReviewUniqueStudents;


            var values= context.Courses.Take(3).ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialTeam()
        {
           var values= context.Instuctors.Take(4).ToList();
            
        return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()   
        {
            var values=context.Testimonials.ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            var value=context.Contacts.FirstOrDefault();

            return PartialView(value);
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

  
    }
}