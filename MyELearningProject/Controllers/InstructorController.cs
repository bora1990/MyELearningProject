using MyELearningProject.DAL.Context;
using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class InstructorController : Controller
    {
       ELearningContext context=new ELearningContext();

        public ActionResult Index()
        {
            var values=context.Instuctors.ToList();
            return View(values);
        }

        public ActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInstructor(Instructor instructor)
        {
            context.Instuctors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult DeleteInstructor(int id)
        {
            var value = context.Instuctors.Find(id);
            context.Instuctors.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInstructor(int id) 
        {
            var value = context.Instuctors.Find(id);
            return View(value);   
        }

        [HttpPost]
        public ActionResult UpdateInstructor(Instructor instructor)
        {
            var value = context.Instuctors.Find(instructor.InstructorID);
            value.Name = instructor.Name;   
            value.Surname = instructor.Surname;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}