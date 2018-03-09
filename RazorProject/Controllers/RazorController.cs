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

        public ActionResult Register()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult Add(string email, string password)
        {
            db.Accounts.Add(new Account { Email = email, Password = password });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Index()
        {
            return View(db.Technologies.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

    }
}
