using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RazorProject.Models;
using System.Data.Entity.Infrastructure;
using DevOne.Security.Cryptography.BCrypt;
using System.Text.RegularExpressions;

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
                ViewBag.ErrorMessage = string.Empty;
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinChars = new Regex(@".{8}");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if (!hasLowerChar.IsMatch(password))
                {
                    ViewBag.ErrorMessage = ViewBag.ErrorMessage + " Password should contain At least one lower case letter.";
                    return View();
                }
                if (!hasUpperChar.IsMatch(password))
                {
                    ViewBag.ErrorMessage = ViewBag.ErrorMessage + " Password should contain At least one upper case letter.";
                    return View();
                }
                if (!hasMinChars.IsMatch(password))
                {
                    ViewBag.ErrorMessage = ViewBag.ErrorMessage + " Password should contain at least eight characters.";
                    return View();
                }
                if (!hasNumber.IsMatch(password))
                {
                    ViewBag.ErrorMessage = ViewBag.ErrorMessage + " Password should contain At least one numeric value.";
                    return View();
                }
                if (!hasSymbols.IsMatch(password))
                {
                    ViewBag.ErrorMessage = ViewBag.ErrorMessage + " Password should contain At least one special case characters.";
                    return View();
                }
                if (ViewBag.ErrorMessage == string.Empty)
                {
                    ViewBag.ErrorMessage = string.Empty;
                    db.Accounts.Add(new Account { Email = email, Password = password });
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("Whoops!");
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

        public ActionResult Edit(int? id)
        {
            Technology technology = db.Technologies.Find(id);
            return View(technology);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Url,Priority,Category,Status")] Technology technology)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technology).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technology);
        }
    }
}
