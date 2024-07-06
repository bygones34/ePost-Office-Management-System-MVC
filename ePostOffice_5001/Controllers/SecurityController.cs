using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ePostOffice_5001.Models.Entity;

namespace ePostOffice_5001.Controllers
{
    public class SecurityController : Controller
    {
        epostofficeEntities db = new epostofficeEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult SignUp(TBLUSER user23)
        {
            var user23InDb = db.TBLUSER.FirstOrDefault(x=>x.USERNAME == user23.USERNAME && x.PASSWORD == user23.PASSWORD);
            if(user23InDb != null)
            {
                FormsAuthentication.SetAuthCookie(user23InDb.USERNAME, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Message2 = "Invalid Username or Password";
                return View();
            }            
        }


        [HttpPost]
        public ActionResult Login(TBLUSER user)
        {
            using (epostofficeEntities dbModel = new epostofficeEntities())
            {
                if (dbModel.TBLUSER.Any(x => x.USERNAME == user.USERNAME))
                {
                    ViewBag.DuplicateMessage = "Username is taken.";
                    return View("Login", user);
                }
                dbModel.TBLUSER.Add(user);
                dbModel.SaveChanges();
            }
            FormsAuthentication.SetAuthCookie(user.USERNAME, false);
            return RedirectToAction("Index", "Home");      

            }

            public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }
       
    }
}