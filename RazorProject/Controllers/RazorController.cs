using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RazorProject.Models;

namespace RazorProject.Controllers
{
    public class RazorController : Controller
    {
        private RazorDB db = new RazorDB();

        public ActionResult Index()
        {
            db.Technologies.Add(new Technology { Title = null, Description = null });
            return View();
            
        }

        


    }
}
