using Microsoft.Ajax.Utilities;
using MyELearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyELearningProject.Controllers
{
    public class ContactController : Controller
    {
        ELearningContext context = new ELearningContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialContactLeft()
        {
            var value=context.Contacts.FirstOrDefault();

            return PartialView(value);
        }
    }
}