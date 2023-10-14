using MyELearningProject.DAL.Context;
using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class ProfileStudentController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            string value = Session["StudentCurrentMail"].ToString();
            ViewBag.mail = Session["StudentCurrentMail"];

            ViewBag.name = context.Students.Where(x => x.Email == value).Select(y => y.Name + " " + y.Surname).FirstOrDefault();

            return View();
        }

        public ActionResult MyCourseList()
        {
            string value = Session["StudentCurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == value).Select(y => y.StudentID).FirstOrDefault();

            var courseList = context.Processes.Where(x => x.StudentID == id).ToList();

            return View(courseList);
        }

        public ActionResult BilgiGuncelle()
        {
            string value = Session["StudentCurrentMail"].ToString();

            var v1 = context.Students.Where(x => x.Email == value).FirstOrDefault();


            return View(v1);
        }

        [HttpPost]
        public ActionResult BilgiGuncelle(Student student)
        {
            var v = context.Students.Find(student.StudentID);
            v.Email = student.Email;
            v.Password = student.Password;
            v.Name = student.Name;
            v.Surname = student.Surname;
            context.SaveChanges();

            return RedirectToAction("BilgiGuncelle","Profile");
        }

    }
}