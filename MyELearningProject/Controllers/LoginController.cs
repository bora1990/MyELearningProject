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
    public class LoginController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(Student student)
        {
            var value=context.Students.FirstOrDefault(x=>x.Email== student.Email && x.Password==student.Password);
            if(value!=null)
            {
                FormsAuthentication.SetAuthCookie(value.Email, false);
                Session["StudentCurrentMail"] = value.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index","ProfileStudent");

            }
            return View();
        }

        public ActionResult LogOutStudent()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Default");
        }


        [HttpGet]
        public ActionResult InstructorLogin()
        {
            return View();
        }  

        [HttpPost]
        public ActionResult InstructorLogin(Instructor instructor)
        {
            var value = context.Instuctors.FirstOrDefault(x => x.Email == instructor.Email && x.Password == instructor.Password);

            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Email, true);
                Session["InstructorCurrentMail"] = value.Email;
                Session.Timeout = 200;
                return RedirectToAction("Index","InstructorAnalysis");
            }
            return View();
        }


        public ActionResult LogOutInstructor()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Default");
        }



        public ActionResult MasterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MasterLogin(Master master)
        {
          var value=  context.Masters.FirstOrDefault(x=>x.Email==master.Email && x.Password==master.Password);

            if(value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Email, false);
                Session["MasterCurrentMail"]= value.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public ActionResult LogOutMaster()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("index", "default");
        }

        public ActionResult AnaLogin()
        {


            return View();
        }

    }
}