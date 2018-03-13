using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RazorProject.Models;
using DevOne.Security.Cryptography.BCrypt;

namespace RazorProject.Controllers
{
    public class RazorController : Controller
    {
        private RazorDB db = new RazorDB();


        public ActionResult Index()
        {
            return View(db.Technologies.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string email, string password)
        {
            if (password.Length < 8)
            {
                ViewBag.ErrorMessage = "Password must be 8 or more characters";
                return View();
            }
            if (password.Any(char.IsDigit))
            {
                ViewBag.ErrorMessage = "Password must contain a numerical character";
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = string.Empty;
                db.Accounts.Add(new Account { Email = email, Password = password });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string title, string description, string priority, string category, string status, string url)
        {
            db.Technologies.Add(new Technology { Title = title, Description = description, Priority = priority, Category = category, Status = status, Url = url});
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

    }
}
