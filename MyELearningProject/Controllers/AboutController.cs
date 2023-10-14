using MyELearningProject.DAL.Context;
using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class AboutController : Controller
    {
        ELearningContext context=new ELearningContext();    
        public ActionResult Index()
        {
            var value=context.Abouts.FirstOrDefault();
            return View(value);
        }

        public ActionResult UpdateAbout(int id)
        {
            var value= context.Abouts.Find(id); 

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutID);
            value.Title = about.Title;
            value.Content = about.Content;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}