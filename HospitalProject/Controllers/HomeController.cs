using HospitalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject.Controllers
{
    public class HomeController : Controller
    {
        //Users to login:
        //admin, 1234
        //user, 1234

        public ActionResult Index()
        {
            //repurposed home index to allow for user login
            //if user is logged in display info else make them login

            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User use)
        {
            //in this method connect to user table and create session if user exist
            //else make them login again

            if (ModelState.IsValid)
            {
                using (ContextClass userContext = new ContextClass())
                {
                    var ins = userContext.Users.Where(a => a.Name.Equals(use.Name) && a.Pass.Equals(use.Pass)).FirstOrDefault();
                    if (ins != null)
                    {
                        Session["UserID"] = ins.Id.ToString();
                        Session["UserName"] = ins.Name.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(use);
        }

    }
}