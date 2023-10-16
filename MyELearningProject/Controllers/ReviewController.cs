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


            List<SelectListItem> courses = (from x in context.Courses.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.CourseID.ToString()
                                               }).ToList();
            ViewBag.v = courses;

            return View();
        }

        [HttpPost]  

        public ActionResult Index(Review review)        
        {
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}