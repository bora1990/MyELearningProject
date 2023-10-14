using MyELearningProject.DAL.Context;
using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class FeatureController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var value = context.Features.ToList();
            return View(value);     
        }

        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(Feature feature)
        {
            context.Features.Add(feature);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
           var value= context.Features.Find(id);

            context.Features.Remove(value);
            context.SaveChanges() ;
            return RedirectToAction("Index");
        }

        public ActionResult UpdateFeature(int id)
        {
            var value=context.Features.Find(id);
            return View(value);         
        }
        [HttpPost]
        public ActionResult UpdateFeature(Feature feature)
        {
            var value=context.Features.Find(feature.FeatureID);
            value.Title = feature.Title;    
            value.Content = feature.Content;
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

    }
}