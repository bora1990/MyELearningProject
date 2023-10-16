using MyELearningProject.DAL.Context;
using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        ELearningContext context =new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult InstructorPanelPartial()
        {
            var email = Session["InstructorCurrentMail"];

            var values = context.Instuctors.Where(x=>x.Email== email).ToList();

            var v1 = context.Instuctors.Where(x=>x.Email==email).Select(y => y.InstructorID).FirstOrDefault();  

            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == v1).Count();

            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();

            ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();

            return PartialView(values);
        }

        public PartialViewResult CommentPartial()
        {

            //select InstructorID from Instructors where Name='Ahmet' and Surname='Ölçen'

            var email = Session["InstructorCurrentMail"];

            var v1 = context.Instuctors.Where(x => x.Email==email).Select(y => y.InstructorID).FirstOrDefault();

            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == v1).Count();
         
            //Select CourseID From Courses where InstructorID=
            var v2 =context.Courses.Where(x=>x.InstructorID==v1).Select(y=>y.CourseID).ToList();

            ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();
            //select* from Comments where CourseID In

            var v3=context.Comments.Where(x=>v2.Contains(x.CourseID)).ToList();

            return PartialView(v3);
        }

        public PartialViewResult CourseListByInstructor()
        {
            var email = Session["InstructorCurrentMail"];
          

            var values=context.Courses.Where(x=>x.Instructor.Email== email).ToList();
            return PartialView(values);
        }



    }
}