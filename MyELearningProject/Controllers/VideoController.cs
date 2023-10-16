using MyELearningProject.DAL.Context;
using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class VideoController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var mail = Session["InstructorCurrentMail"];
            var id=context.Instuctors.Where(x=>x.Email== mail).Select(y=>y.InstructorID).FirstOrDefault();  

            var values = context.Videos.Where(x=>x.Course.InstructorID==id).ToList();

            return View(values);
        }

        public ActionResult VideoEkle()
        {
            List<SelectListItem> course = (from x in context.Courses.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.CourseID.ToString()
                                               }).ToList();
            ViewBag.v = course;

            return View();
        }
        [HttpPost]

        public ActionResult VideoEkle(Video video)
        {
            context.Videos.Add(video);
            context.SaveChanges();
            return RedirectToAction("Index");
  
        }

        public ActionResult VideoSil()
        {
            var mail = Session["InstructorCurrentMail"];

            var id = context.Videos.Where(x => x.Course.Instructor.Email == mail).FirstOrDefault();

            var value = context.Videos.Find(id);

            context.Videos.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }




    }
}