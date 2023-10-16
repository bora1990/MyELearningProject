using MyELearningProject.DAL.Context;
using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyELearningProject.Controllers
{
    public class ProfileInstructorController : Controller
    {
        ELearningContext context=new ELearningContext();


        [HttpGet]
        public ActionResult ProfilGuncelle()
        {
            var email = Session["InstructorCurrentMail"];

            var id = context.Instuctors.Where(x => x.Email == email).Select(x => x.InstructorID).FirstOrDefault();

            var value = context.Instuctors.Find(id);

            return View(value);
           
        }
        [HttpPost]
        public ActionResult ProfilGuncelle(Instructor instructor)
        {

            var value = context.Instuctors.Find(instructor.InstructorID);
            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
            value.Email = instructor.Email;
            value.Title = instructor.Title;
            value.ImageUrl = instructor.ImageUrl;

            context.SaveChanges();
            return RedirectToAction("Index", "InstructorAnalysis");
        
        }

        [HttpGet]

        public ActionResult KursEkleCikar()
        {
            var email = Session["InstructorCurrentMail"];

            var id = context.Instuctors.Where(x => x.Email == email).Select(x => x.InstructorID).FirstOrDefault();

            var myCourses=context.Courses.Where(x=>x.InstructorID == id).ToList();


            return View(myCourses);
        }

        public ActionResult ProfilGuncelle(int id)
        {


            return View();
        }


        public ActionResult KursVideos(int id)
        {
            var kursVideos = context.Videos.Where(video => video.CourseID == id).ToList();


            return View(kursVideos);

        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            var email = Session["InstructorCurrentMail"];

            var ins = context.Instuctors.Where(x=>x.Email == email).Select(y=>y.InstructorID).FirstOrDefault();

            var catid=context.Courses.Where(x=>x.InstructorID== ins).Select(y=>y.CategoryID).FirstOrDefault();


            List<SelectListItem> categories = (from x in context.Categories.Where(i=>i.CategoryID== catid).ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.v = categories;

            ViewBag.instructor = ins;


            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("KursEkleCikar", "ProfileInstructor");
        }

        public ActionResult DeleteCourse(int id)
        {

            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("KursEkleCikar", "ProfileInstructor");

        }

        public ActionResult UpdateCourse(int id)
        {
           var email = Session["InstructorCurrentMail"];

            var ins = context.Instuctors.Where(x=>x.Email == email).Select(y=>y.InstructorID).FirstOrDefault();

            var catid=context.Courses.Where(x=>x.InstructorID== ins).Select(y=>y.CategoryID).FirstOrDefault();


            List<SelectListItem> categories = (from x in context.Categories.Where(i=>i.CategoryID== catid).ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.v = categories;

            ViewBag.instructor = ins;


            var value = context.Courses.Find(id);

            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseID);
            value.Title = course.Title;
            value.CategoryID = course.CategoryID;
            value.Duration = course.Duration;
            value.ImageUrl = course.ImageUrl;
            value.InstructorID = course.InstructorID;
            value.Price = course.Price;
            context.SaveChanges();
            return RedirectToAction("KursEkleCikar");

        }


    }
}